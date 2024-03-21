using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class PlayerMovement : MonoBehaviour
{
    public AudioSource sound;

    public float runSpeed = 2.2f;
    public float jumpSpeed = 3f;
    public float doubleJumpSpeed = 2.5f;
    private bool canDoubleJump;

    Rigidbody2D rb2D;
    public SpriteRenderer spriteRenderer;
    public Animator animator;

    public bool betterJump = false;
    public float fallMultiplier = 0.5f;
    public float lowJumpMultiplier = 1f;

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();//esto es igual a this.GetComponent
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {

        if (Input.GetKey("w"))
        {
            if (CheckGround.isGrounded)
            {
                rb2D.velocity = new Vector2(rb2D.velocity.x, jumpSpeed);
                animator.SetBool("Jump", true);
                sound.Play();
                canDoubleJump = true;
            }
            else
            {
                if (Input.GetKeyDown("w"))
                {
                    if (canDoubleJump)
                    {
                        animator.SetBool("DoubleJump", true);
                        rb2D.velocity = new Vector2(rb2D.velocity.x, doubleJumpSpeed);
                        canDoubleJump = false;
                    }
                }
            }
        }

        if (betterJump)
        {
            if (rb2D.velocity.y < 0)
            {
                rb2D.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier) * Time.deltaTime;
            }
            if (rb2D.velocity.y > 0 && !Input.GetKey("w"))
            {
                rb2D.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier) * Time.deltaTime;
            }
        }

        if (!CheckGround.isGrounded)
        {
            animator.SetBool("Jump", true);
            animator.SetBool("Run", false);
            if (rb2D.velocity.y <= 0)
            {
                animator.SetBool("Jump", false);
                animator.SetBool("DoubleJump", false);
                animator.SetBool("Fall", true);
            }
        }


        if (CheckGround.isGrounded)
        {
            animator.SetBool("Fall", false);
            animator.SetBool("Jump", false);
            animator.SetBool("DoubleJump", false);
            canDoubleJump = true;
        }
    }
    void FixedUpdate()
    {
        if (Input.GetKey("d") || (Input.GetKey("right")))
        {
            rb2D.velocity = new Vector2(runSpeed, rb2D.velocity.y);//Vector 2 es una array de 2 componentes
            spriteRenderer.flipX = false;
            animator.SetBool("Run", true);
        }

        else if (Input.GetKey("a") || (Input.GetKey("left")))
        {
            rb2D.velocity = new Vector2(-runSpeed, rb2D.velocity.y);
            spriteRenderer.flipX = true;
            animator.SetBool("Run", true);
        }

        else
        {
            rb2D.velocity = new Vector2(0, rb2D.velocity.y);
            animator.SetBool("Run", false);
        }





    }
}
