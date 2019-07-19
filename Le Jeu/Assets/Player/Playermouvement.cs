using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playermouvement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    public float dashForce = 15f;
    public bool isGrounded = false;
    void Start()
    {
        
    }

    void Update()
    {
        Jump();
        Dash();
        Vector3 mouvement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += mouvement * Time.deltaTime * moveSpeed;
    }

    void Jump()
    {
        if(Input.GetButtonDown("Jump") && isGrounded == true)
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }
    }

    void Dash()
    {
        if (Input.GetButtonDown("Dash"))
        {
            //gameObject.GetComponent<Rigidbody2D>().gravityScale = 0;
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(dashForce, 0f), ForceMode2D.Impulse);
        }
    }
}
