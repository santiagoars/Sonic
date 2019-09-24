using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{

    private Vector3 offset;

    public GameObject sonic;


    void Start()
    {
        this.offset = transform.position - sonic.transform.position;
    }

    void LateUpdate()
    {
        transform.position = sonic.transform.position + offset;
    }
}
