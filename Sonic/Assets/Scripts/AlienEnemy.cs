using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienEnemy : MonoBehaviour
{

    private float min, max;

    private Rigidbody2D rb;
    private SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {
        this.rb = GetComponent<Rigidbody2D>();
        this.sr = GetComponent<SpriteRenderer>();
        this.min = transform.position.x;
        this.max = min + 10;

    }

    // Update is called once per frame
    void Update()
    {

        transform.position = new Vector2(Mathf.PingPong(Time.time * 3, max - min) + min, transform.position.y);
    }
}
