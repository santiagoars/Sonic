using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public int speed;
    public Transform target;

    // Start is called before the first frame update
    void Start()
    {
        this.speed = 3;
        this.target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (collision.transform.position.y > transform.position.y + 0.1)
            {
                collision.transform.GetComponent<Rigidbody2D>().AddForce(25 * transform.up, ForceMode2D.Impulse);
            }
            else
            {
                collision.GetComponent<Sonic>().damage();
            }

        }
    }
}
