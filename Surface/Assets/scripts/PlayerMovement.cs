using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float walkSpeed = 2f;
    public float runSpeed = 5f;
    public float jumpForce = 10f;
    public LayerMask groundLayer;
    private Rigidbody2D rb;
    private bool isGrounded;
    private bool isSprinting;
    float stamina;
    public float maxStamina;
    public Slider staminaBar;
    public Slider usageWheel;

    void Start()
    {
        stamina = maxStamina;
        rb = GetComponent<Rigidbody2D>();
        isGrounded = transform.Find("Groundsensor").GetComponent<PlayerSensor>();
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
        Move();
        Jump();



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

    void Move()
    {
        float moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);
    }

    void Jump()
    {
        //isGrounded = Physics2D.Raycast(transform.position, Vector2.down, 1f, groundLayer);
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }
}