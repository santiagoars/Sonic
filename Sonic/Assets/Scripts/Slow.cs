using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slow : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            this.GetComponent<SpriteRenderer>().enabled = false;
            this.GetComponent<BoxCollider2D>().enabled = false;
            this.GetComponent<AudioSource>().Play();
            collision.GetComponent<Sonic>().changeSpeed(0.5f);
            yield return new WaitForSeconds(7);
            collision.GetComponent<Sonic>().changeSpeed(2f);
        }
    }
}
