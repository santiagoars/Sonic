using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Sonic : MonoBehaviour
{
    public Transform spawnRef;

    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private Animator anim;
    private float speed,
                  speedV;
    private bool isGrounded;
    public bool shield = false;
    public int health = 3,
               resNum = 3,
               jumpHeight = 8;

    public GameObject spriteShield;
    public Text scoreDisplay;
    private int score;

    // Start is called before the first frame update
    void Start()
    {
        this.rb = GetComponent<Rigidbody2D>();
        this.sr = GetComponent<SpriteRenderer>();
        this.anim = GetComponent<Animator>();
        spriteShield.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0f);
        this.speedV = 15.0f;
    }

    // Update is called once per frame
    void Update()
    {
        detectMovement();
        flipCharacter();
        detectJump();
        grounded();
        //isDead();

        this.scoreDisplay.text = "RINGS:" + this.score.ToString();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isGrounded = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag.Equals("ring"))
        {
            this.score++;
        }
        else if (collision.CompareTag("enemy"))
        {
            this.damage();
        }
    }

    private void detectMovement()
    {
        float h = Input.GetAxis("Horizontal");
        this.speed = h * this.speedV * Time.deltaTime;
        transform.Translate(new Vector3(speed, 0, 0));
        if (isGrounded)
        {
            this.anim.SetFloat("minSpeed", Mathf.Abs(speed));
            this.anim.SetFloat("Speed", Mathf.Abs(speed));
        }
    }

    public void changeSpeed(float mult)
    {
        this.speedV *= mult;
    }

    /*private void isDead()
    {
        if (transform.position.y < -14)
        {
            Debug.Log("Reiniciando nivel... por nivel de abajo");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            respawn();
        }
    }*/

    private void flipCharacter()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            this.sr.flipX = false;
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            this.sr.flipX = true;
        }
    }

    private void detectJump()
    {
        if ((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Space)) && isGrounded)
        {
            this.rb.velocity = Vector2.up * this.jumpHeight;
            isGrounded = false;
        }
    }

    private void grounded()
    {
        if (isGrounded)
        {
            this.anim.SetBool("isJumping", false);
        }else if (!isGrounded)
        {
            this.anim.SetBool("isJumping", true);
        }
    }

    public void respawn()
    {
        this.resNum--;
        if (resNum == 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        else
        {
            this.health = 3;
            this.transform.position = this.spawnRef.position;
        }
        
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

    public void doubleJumpHeight()
    {
        this.jumpHeight *= 2;
    }

    public void halfJumpHeight()
    {
        this.jumpHeight /= 2;
    }

}
