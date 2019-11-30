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

    private Vector3 target;
    private float start, end;



    // Start is called before the first frame update
    void Start()
    {
        this.target = transform.position;
        start = transform.position.x;
        end = transform.position.x + length;
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
            if (sonic.minY.position.y > this.maxY.position.y)
            {
                StartCoroutine(destroyEnemy());
                collision.transform.GetComponent<Rigidbody2D>().AddForce(25 * transform.up, ForceMode2D.Impulse);
            }else if (sonic.minY.position.y <= this.maxY.position.y)
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
        }
        else if (transform.position.x.Equals(end))
        {
            target.x = start;
        }

        transform.position = Vector3.MoveTowards(transform.position, target, 2 * Time.deltaTime);
    }

    private void enemyTwo()
    {
        transform.position = new Vector2(transform.position.x, Mathf.PingPong(Time.time * speed, length));
    }

}
