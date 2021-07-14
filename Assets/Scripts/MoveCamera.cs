using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public Transform UFO;
    private Vector3 vector;
    void Start()
    {
        vector = transform.position - UFO.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = vector + UFO.position;
    }
}
