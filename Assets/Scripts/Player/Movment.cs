using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movment : MonoBehaviour
{
    [SerializeField] private float speed = 8f;
    [SerializeField] private float jumpForce = 3.5f;
    [SerializeField] private int numberOfJumps = 1;


    private int jumpNum;
    private bool isGrounded = false;
    private bool onWall = false;
    private Rigidbody2D rigid;
    private Transform lastTouchedObject;

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        jumpNum = numberOfJumps;
    }

    void Update()
    {
        Movement();
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W)))
            Jump();
    }


    private void Movement()
    {
        float x = Input.GetAxis("Horizontal");
        if (onWall)
        {
            if (lastTouchedObject.position.x > transform.position.x && x <= 0)
                rigid.velocity = new Vector2(x * speed, rigid.velocity.y);
            else if (lastTouchedObject.position.x < transform.position.x && x >= 0)
                rigid.velocity = new Vector2(x * speed, rigid.velocity.y);
        }
        else
        {
            rigid.velocity = new Vector2(x * speed, rigid.velocity.y);
        }
    }


    private void Jump()
    {
        if (numberOfJumps > 0 && isGrounded)
        {
            rigid.AddForce(new Vector2(0, jumpForce));
            numberOfJumps--;
        }
    }

    private void Animations() { 
        //future animations
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            numberOfJumps = jumpNum;
            lastTouchedObject = collision.gameObject.transform;
            onWall = false;
        }
        else if (collision.gameObject.tag == "JumpWall")
        {
            if (lastTouchedObject != collision.gameObject.transform)
                numberOfJumps = 1;
            lastTouchedObject = collision.gameObject.transform;
            onWall = true;
        }

        isGrounded = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        onWall = false;
        isGrounded = false;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
            isGrounded = true;
    }



}
