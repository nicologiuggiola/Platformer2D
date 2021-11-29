using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private Animator anim;
    private SpriteRenderer rend;
    private GameManager gameManager;
    private CapsuleCollider2D collid;
    public float speed;
    public float jumpSpeed;
    private bool canJump = true;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        rend = GetComponent<SpriteRenderer>();
        collid = GetComponent<CapsuleCollider2D>();
        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        rb2d.velocity = new Vector2(x * speed, rb2d.velocity.y);

        if (x != 0)
        {
            anim.SetBool("isWalking", true);
        }
        else
        {
            anim.SetBool("isWalking", false);
        }

        if (x < 0)
        {
            rend.flipX = true;
        }
        else if (x > 0)
        {
            rend.flipX = false;
        }

        if (Input.GetKeyDown(KeyCode.Space) && canJump)
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, jumpSpeed);
            //canJump = false;
            anim.SetTrigger("Jump");
        }

        if (isGrounded())
        {
            canJump = true;
        }
        else
        {
            canJump = false;
        }
    }

    private void FixedUpdate()
    {
        
    }

    private bool isGrounded()
    {
       return transform.Find("GroundCheck").GetComponent<GroundCheck>().isGrounded;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Trap"))
        {
            rb2d.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY;
            gameManager.playerDead = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name.Equals("dz"))
        {
            rb2d.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY;
            gameManager.playerDead = true;
        }
    }

    public void Unlock()
    {
        rb2d.constraints = RigidbodyConstraints2D.None;
        rb2d.constraints = RigidbodyConstraints2D.FreezeRotation;
    }
}
