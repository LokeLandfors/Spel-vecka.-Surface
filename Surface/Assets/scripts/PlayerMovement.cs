using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float walkSpeed = 2f;
    public float runSpeed = 5f;
    public float jumpForce = 10f;
    private bool isFacingRight = true; // Kolla vilket håll karaktären tittar i
    private Rigidbody2D rb;
    private bool isGrounded;
    float stamina;
    public float maxStamina;
    public Slider staminaBar;
    public Slider usageWheel;
    private Animator animator;
    public SpriteRenderer sprite;
    public Animator anim;
    playerSlide slide;

    void Start()
    {
        stamina = maxStamina;
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        slide = GetComponent<playerSlide>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isGrounded = true;
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false;
    }

    void Update()
    {
        float moveDirection = Input.GetAxis("Horizontal");  // Kolla om vi rör oss horisontellt

        Move(moveDirection); // Flytta spelaren
        
        Jump();

        if (Input.GetKeyDown(KeyCode.A))
        {
            sprite.flipX = true;
            isFacingRight = false;
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            sprite.flipX = false;
            isFacingRight = true;
        }

        if (Input.GetKey("left shift") == true)
        {
            if (stamina > 0)
            {
                moveSpeed = runSpeed;
                stamina -= 10 * Time.deltaTime;
            }
            usageWheel.value = stamina / maxStamina + 0.05f;

        }
        else
        {
            if (stamina < maxStamina)
            {
                stamina += 30 * Time.deltaTime;
                moveSpeed = walkSpeed;
            }

            usageWheel.value = stamina / maxStamina;
        }
        staminaBar.value = stamina / maxStamina;

        if (stamina <= 0)
        {
            moveSpeed = walkSpeed;
        }
    }



    void Move(float direction)
    {
        float moveInput = Input.GetAxis("Horizontal");
        if (slide.isSliding == false)
        {
            rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);
        }
        

        float absoluteSpeed = Mathf.Abs(direction * moveSpeed);
        animator.SetFloat("Speed", absoluteSpeed); // Använd Speed parametern i animatorn
    }

    void Jump()
    {
        //isGrounded = Physics2D.Raycast(transform.position, Vector2.down, 1f, groundLayer);
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            stamina -= 20;
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }
    private void Flip()
    {
        isFacingRight = !isFacingRight;  // Flippa player spriten horizontellt
        transform.Rotate(0f, 180f, 0f);
        //Transform firepoint = transform.Find("FirePoint");
        //firepoint.localPosition = new Vector3(-firepoint.localPosition.x, firepoint.localPosition.y, firepoint.localPosition.z);
    }
}