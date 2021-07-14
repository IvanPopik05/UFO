using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneFader : MonoBehaviour
{
    public Image img;
    public AnimationCurve curve;

    private void Start() {
        StartCoroutine(FadeIn());
    }

    public void FadeTo(string scene)
    {
        StartCoroutine(FadeOut(scene));
    }

    IEnumerator FadeIn()
    {
        float timeColor = 1f;

        while(timeColor > 0)
        {
            timeColor -= Time.deltaTime;
            float AlphaCurve = curve.Evaluate(timeColor);
            img.color = new Color(0,0,0,AlphaCurve);
            yield return 0;
        }
    }
    IEnumerator FadeOut(string scene)
    {
        float timeColor = 0f;

        while(timeColor < 1)
        {
            timeColor += Time.deltaTime;
            float AlphaCurve = curve.Evaluate(timeColor);
            img.color = new Color(0,0,0,AlphaCurve);
            yield return 0;
        }
        SceneManager.LoadScene(scene);
    }
}
