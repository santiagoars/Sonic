using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{

    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            anim.SetBool("begin", true);
            Sonic sc = collision.GetComponent<Sonic>();
            sc.GetComponent<Sonic>().spawnRef = GetComponent<Transform>();
            Debug.Log("Spawnw cambiado x: " + sc.spawnRef.position.x + " y: " + sc.spawnRef.position.y + " z: " + sc.spawnRef.position.z);

        }
    }
}
