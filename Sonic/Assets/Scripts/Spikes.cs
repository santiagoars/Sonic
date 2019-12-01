using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{

    public Sonic sonic;
    public Transform maxY;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (sonic.minY.position.y > maxY.position.y)
        {
            sonic.damage();
            sonic.dam = true;
            sonic.anim.SetTrigger("damage");
            sonic.rb.AddForce(transform.up * 20, ForceMode2D.Impulse);
        }
    }
}
