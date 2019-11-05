using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{

    private Vector3 offset;
    private Vector3 onset;

    public GameObject sonic;


    void Start()
    {
        this.offset = transform.position - sonic.transform.position;
        this.onset = new Vector3(0, -1.5f, 0);
    }

    void LateUpdate()
    {
        transform.position = sonic.transform.position + offset + onset;
    }
}
