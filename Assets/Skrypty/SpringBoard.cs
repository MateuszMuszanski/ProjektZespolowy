using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringBoard : MonoBehaviour
{
    public float force;
    public float shootForce;
    public Rigidbody2D rb;
    private float moveInput;

    public LayerMask mask;
    public Transform feetPos;
    public float overlap;
    private bool inCircle;

    private Animator animator;

    // Update is called once per frame
    void Update()
    {
        inCircle = Physics2D.OverlapCircle(feetPos.position, overlap, mask);
        animator = GetComponent<Animator>();
    }
    private void FixedUpdate()
    {
        if (inCircle == true && animator != null)
        {
            animator.SetTrigger("inAir");
            moveInput = Input.GetAxisRaw("Horizontal");
            rb.velocity = new Vector2(moveInput * shootForce, force);
        }
        else if (inCircle == true)
        {
            moveInput = Input.GetAxisRaw("Horizontal");
            rb.velocity = new Vector2(moveInput * shootForce, force);
        }
    }
}
