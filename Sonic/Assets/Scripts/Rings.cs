using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rings : MonoBehaviour
{

    public AudioClip ringSound; 


    // Start is called before the first frame update
    void Start()
    {
        GetComponent<AudioSource>().playOnAwake = false;
        GetComponent<AudioSource>().clip = ringSound;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag.Equals("Player"))
        {
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<AudioSource>().Play();
            GetComponent<BoxCollider2D>().enabled = false;
        }

    }

}
