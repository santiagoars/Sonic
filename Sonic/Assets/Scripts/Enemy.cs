using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
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
            if (collision.transform.position.y > transform.position.y + 0.1)
            {
                StartCoroutine(destroyEnemy());
            }
            else
            {
                collision.GetComponent<Sonic>().damage();
            }

        }
    }

    IEnumerator destroyEnemy()
    {
        yield return new WaitForSeconds(0.1f);
        Destroy(this.gameObject);
    }
}
