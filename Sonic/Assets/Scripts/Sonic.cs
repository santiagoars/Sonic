using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Sonic : MonoBehaviour
{
    public Transform spawnRef;
    public Transform minY;
    public bool dam;
    public Rigidbody2D rb;
    private SpriteRenderer sr;
    public Animator anim;
    public LayerMask groundLayer;
    private float speed,
                  speedV;
    public bool isGrounded;
    public bool shield = false;
    public int resNum = 3,
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
        this.score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        detectMovement();
        flipCharacter();
        detectJump();
        scoreToCanvas();
        jumpingAnim();
    }


    public bool isOnGround()
    {
        Vector2 position = transform.position;
        Vector2 direction = Vector2.down;
        float distance = 1f;

        Debug.DrawRay(position, direction, Color.green);
        RaycastHit2D hit = Physics2D.Raycast(position, direction, distance, groundLayer);
        if (hit.collider != null)
        {
            return true;
        }

        return false;
    }


    private void scoreToCanvas()
    {
        this.scoreDisplay.text = "RINGS:" + this.score.ToString();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag.Equals("ring"))
        {
            this.score++;
        }
    }

    private void detectMovement()
    {
        float h = Input.GetAxis("Horizontal");
        this.speed = h * this.speedV * Time.deltaTime;
        transform.Translate(new Vector3(speed, 0, 0));
        if (isOnGround() == true)
        {
            this.anim.SetFloat("minSpeed", Mathf.Abs(speed));
            this.anim.SetFloat("Speed", Mathf.Abs(speed));
        }
    }

    public void changeSpeed(float mult)
    {
        this.speedV *= mult;
    }


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
        if ((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Space)) && isOnGround() == true)
        {
            this.rb.velocity = Vector2.up * this.jumpHeight;
        }
    }

    private void jumpingAnim()
    {
        if (isOnGround() == true)
        {
            this.anim.SetBool("isJumping", false);
        }else if (isOnGround() == false)
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
            this.transform.position = this.spawnRef.position;
        }
        
    }


    public void damage()
    {
        if (this.shield)
        {
            breakShield();
            return;
        }
        else
        {
            this.score += -2;
            if (this.score <= 0 && dam)
            {
                respawn();
                this.dam = false;
                this.score = 0;
            }
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
