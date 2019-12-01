using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffJump : MonoBehaviour
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
            Destroy(this.gameObject);
            collision.GetComponent<Sonic>().doubleJumpHeight();
            yield return new WaitForSeconds(7);
            collision.GetComponent<Sonic>().halfJumpHeight();
        }
    }
}
