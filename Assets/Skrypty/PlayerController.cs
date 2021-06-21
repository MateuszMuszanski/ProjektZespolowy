using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Animator animator;

    private Rigidbody2D rb;
    public float speed;
    private float moveInput;

    private bool isGrounded;
    public Transform feetPos;
    public float checkRadius;
    public LayerMask whatIsGround;
    public float jumpForce;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        moveInput = Input.GetAxisRaw("Horizontal");
        if (moveInput > 0)
        {
            moveInput = 1;
        }
        else if (moveInput < 0)
        {
            moveInput = -1;
        }
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
    }

    private void Update()
    {
        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);

        if (moveInput == 0)
        {
            animator.SetBool("isRunning", false);
        }
        else
        {
            animator.SetBool("isRunning", true);
        }

        if (moveInput > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else if (moveInput < 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }

        if (isGrounded == true && (Input.GetKeyDown(KeyCode.Space) || Input.GetKey(KeyCode.Joystick1Button0)))
        {
            animator.SetTrigger("inAir");

            rb.velocity = Vector2.up * jumpForce;
        }

        if (isGrounded == true)
        {
            animator.SetBool("isJumping", false);
        }
        else
        {
            animator.SetBool("isJumping", true);
        }
    }
}
