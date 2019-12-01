using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public Sonic sonic;
    public Transform maxY;
    public int enemyType;
    public float speed;
    public float length;
    public AudioClip oof;

    private Vector3 target;
    private float start, end;
    private SpriteRenderer sr;
    private AudioSource audioSr;



    // Start is called before the first frame update
    void Start()
    {
        this.target = transform.position;
        start = transform.position.x;
        end = transform.position.x + length;
        this.sr = GetComponent<SpriteRenderer>();
        this.audioSr = GetComponent<AudioSource>();
        this.audioSr.clip = oof;
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyType == 1)
        {
            enemyOne();
        }else if (enemyType == 2)
        {
            enemyTwo();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if ((sonic.minY.position.y > this.maxY.position.y || sonic.isOnGround() == false))
            {
                this.audioSr.Play();
                GetComponent<SpriteRenderer>().enabled = false;
                GetComponent<BoxCollider2D>().enabled = false;
            }
            else if ((sonic.minY.position.y <= this.maxY.position.y))
            {
                sonic.dam = true;
                sonic.damage();
                if (transform.position.x > collision.transform.position.x)
                {
                    sonic.anim.SetTrigger("damage");
                    sonic.transform.Translate(-25 * Time.deltaTime * 7, 0, 0, Space.World);
                }
                else if (transform.position.x < collision.transform.position.x)
                {
                    sonic.anim.SetTrigger("damage");
                    sonic.transform.Translate(25 * Time.deltaTime * 7, 0, 0, Space.World);
                }
            }
        }
    }


    IEnumerator destroyEnemy()
    {
        yield return new WaitForSeconds(0.1f);
        Destroy(this.gameObject);
    }

    private void enemyOne()
    {
        if (transform.position.x.Equals(start))
        {
            target.x = end;
            this.sr.flipX = true;
        }
        else if (transform.position.x.Equals(end))
        {
            target.x = start;
            this.sr.flipX = false;
        }

        transform.position = Vector3.MoveTowards(transform.position, target, 2 * Time.deltaTime);
    }

    private void enemyTwo()
    {
        transform.position = new Vector2(transform.position.x, Mathf.PingPong(Time.time * speed, length));
    }


}
