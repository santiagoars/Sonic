using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sonic : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private Animator anim;
    private float speed;

    // Start is called before the first frame update
    void Start()
    {
        this.rb = GetComponent<Rigidbody2D>();
        this.sr = GetComponent<SpriteRenderer>();
        this.anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        //float v = Input.GetAxis("Vertical");

        this.speed = h * 15 * Time.deltaTime;
        print(this.speed);
        this.anim.SetFloat("Speed", Mathf.Abs(speed));
        

        transform.Translate(new Vector3(speed, 0, 0));

        if (Input.GetKey(KeyCode.RightArrow))
        {
            this.sr.flipX = false;
            this.anim.SetBool("isClicking", true);
        }else if (Input.GetKey(KeyCode.LeftArrow))
        {
            this.sr.flipX = true;
            this.anim.SetBool("isClicking", true);
        }
        else
        {
            this.anim.SetBool("isClicking", false);
        }

    }
}
