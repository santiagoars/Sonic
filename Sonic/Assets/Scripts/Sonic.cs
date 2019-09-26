using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sonic : MonoBehaviour
{
    public Transform spawnRef;

    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private Animator anim;
    private float speed;
    private bool isGrounded;
    public bool shield = false;
    public int health = 3;

    public GameObject spriteShield;

    // Start is called before the first frame update
    void Start()
    {
        this.rb = GetComponent<Rigidbody2D>();
        this.sr = GetComponent<SpriteRenderer>();
        this.anim = GetComponent<Animator>();
        spriteShield.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        detectMovement();
        flipCharacter();
        detectJump();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isGrounded = true;
    }

    private void detectMovement()
    {
        float h = Input.GetAxis("Horizontal");
        this.speed = h * 15 * Time.deltaTime;
        transform.Translate(new Vector3(speed, 0, 0));
        this.anim.SetFloat("Speed", Mathf.Abs(speed));
    }

    private void flipCharacter()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            this.sr.flipX = false;
            this.anim.SetBool("isClicking", true);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            this.sr.flipX = true;
            this.anim.SetBool("isClicking", true);
        }
        else
        {
            this.anim.SetBool("isClicking", false);
        }
    }

    private void detectJump()
    {
        if ((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Space)) && isGrounded)
        {
            this.rb.velocity = Vector2.up * 8;
            isGrounded = false;
        }
    }

    public void respawn()
    {
        this.health = 3;
        this.transform.position = this.spawnRef.position;
    }

    public void heal()
    {
        this.health++;
    }

    public void damage()
    {
        if (this.shield)
        {
            breakShield();
            return;
        }

        this.health--;
        Debug.Log("Vida restante:" + this.health);

        if (this.health == 0)
        {
            respawn();
        }
    }

    public void castSHield()
    {
        spriteShield.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.5f);
        this.shield = true;
    }

    public void breakShield()
    {
        spriteShield.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0f);
        this.shield = false;
    }

}
