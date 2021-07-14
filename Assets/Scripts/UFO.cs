using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UFO : MonoBehaviour
{
    [SerializeField] private Rigidbody leftLeg;
    [SerializeField] private Rigidbody rightLeg;
    [SerializeField] private float moveRotation = 0.8f;
    [SerializeField] private float force;
    [SerializeField] private SceneLoader sceneLoader;
    [SerializeField] private Slider leftSlider;
    [SerializeField] private Slider rightSlider;
    [SerializeField] private Text leftText;
    [SerializeField] private Text rightText;
    [SerializeField] private AudioSource[] audios;
    [SerializeField] private ParticleSystem ExplosionSystem;
    [SerializeField] private float timer;
    [SerializeField] private GameObject[] addRigidbody;
    [SerializeField] private SceneFader sceneFader;
    [SerializeField] private GameManager gameManager;
    void Start()
    {
        leftSlider.maxValue = force;
        rightSlider.maxValue = force;
        audios = GetComponents<AudioSource>();
        sceneLoader = FindObjectOfType<SceneLoader>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 minForce = Vector3.up * force * moveRotation;
        Vector3 maxForce = Vector3.up * force;

        Vector3 leftForce = Vector3.zero;
        Vector3 rightForce = Vector3.zero;
        if(Input.GetKey(KeyCode.A))
        {
            // Значение левого сопла должно быть 80%, а правого 100%
            leftForce = minForce;
            rightForce = maxForce;
        }
        else if(Input.GetKey(KeyCode.D))
        {
            leftForce = maxForce;
            rightForce = minForce;
        }
        else if(Input.GetKey(KeyCode.Space))
        {
            // rb.AddForce(Vector3.up * force);
            
            rightForce = maxForce;
            leftForce = maxForce;
        }
        leftLeg.AddRelativeForce(leftForce);
        rightLeg.AddRelativeForce(rightForce);

        leftSlider.value = leftForce.y * Time.deltaTime * 50f;
        rightSlider.value = rightForce.y * Time.deltaTime * 50f;
        
        rightText.text = rightForce.y + "Н";
        leftText.text = leftForce.y + "Н";

        if(leftForce.y + rightForce.y > 0 && !audios[0].isPlaying)
        {
            audios[0].Play();
        }else if(leftForce.y + rightForce.y == 0)
        {
            audios[0].Pause();
        }
    }
    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.CompareTag("Enemy"))
        {
            foreach (var obj in addRigidbody)
            {
                obj.AddComponent<Rigidbody>();
            }
            audios[1].Play();
            ExplosionSystem.Play();
            if(timer == 0){
            gameManager.GameIsOver();
            }
            timer--;
        }
        if(other.gameObject.CompareTag("Girl"))
        {
            gameManager.NextIsLevel();
        }
    }
    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Enemy"))
        {
            audios[1].Play();
            ExplosionSystem.Play();
            gameManager.GameIsOver();
        }
    }
}
