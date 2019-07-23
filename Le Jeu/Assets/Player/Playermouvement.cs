using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playermouvement : MonoBehaviour
{
    private bool facingRight = true;

    public float moveSpeed = 15f;
    public float jumpForce = 20f;
    public float dashForce = 30f;
    public bool isGrounded = false;
    public bool alreadyDash = false;

    private float jumpTimer;
    public float jumpTime;

    private float dashTimer;
    public float dashTime;

    public bool isJumping = false;
    public bool isDashing = false;
    void Update()
    {
        Jump();
        Dash();

        /*Player mouvement droite gauche*/
        Vector3 mouvement = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f);
        transform.position += mouvement * Time.deltaTime * moveSpeed;

        /*Dashing timer*/
        if (isDashing == true)
        {
            if (dashTimer > 0)
            {
                dashTimer -= Time.deltaTime;
            }
            else
            {
                gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 0f);
                gameObject.GetComponent<Rigidbody2D>().gravityScale = 9;
                isDashing = false;
            }
        }
        
        /*Flip selon facing right or left*/
        if (mouvement.x > 0 && !facingRight)
        {
            Flip();
        }
       
        else if (mouvement.x < 0 && facingRight)
        {
            Flip();
        }
    }

    void Jump()
    {
        if(Input.GetButtonDown("Jump") && isGrounded == true && isDashing == false)
        {    
            isJumping = true;
            jumpTimer = jumpTime;
            gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.up * jumpForce;
        }
        if (Input.GetButton("Jump") && isJumping == true)
        {
            if (jumpTimer > 0 && isDashing == false)
            {
                gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.up * jumpForce;
                jumpTimer -= Time.deltaTime;
            }
            else
            {
                isJumping = false;
            }
        }
        if (Input.GetButtonUp("Jump"))
        {
            isJumping = false;
        }
    }

    void Dash()
    {
        if (Input.GetButtonDown("Dash") && isDashing == false && alreadyDash == false)
        {
            isDashing = true;
            dashTimer = dashTime;
            if(facingRight == true)
            {
                gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(dashForce, 0f);
            }
            else
            {
                gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(-dashForce, 0f);
            }
            gameObject.GetComponent<Rigidbody2D>().gravityScale = 0;
            if (isGrounded == false)
            {
                alreadyDash = true;
            }
        }
        if (isGrounded == true)
        {
            alreadyDash = false;
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        transform.Rotate(0f, 180f, 0f);
    }
}
