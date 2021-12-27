using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movment : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    [SerializeField] private float jumpForce = 400f;
    [SerializeField] private int numberOfJumps = 1;


    private int jumpNum;
    private bool isGrounded = false;
    private Rigidbody2D rigid;
    private Transform lastTouchedObject;
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        jumpNum = numberOfJumps;
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W)))
            Jump();
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            numberOfJumps = jumpNum;
            lastTouchedObject = collision.gameObject.transform;
        }
        else if (collision.gameObject.tag == "JumpWall")
        {
            if(lastTouchedObject != collision.gameObject.transform)
                numberOfJumps = 1;
            lastTouchedObject = collision.gameObject.transform;
        }

        isGrounded = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false;
    }

    private void Movement()
    {
        float x = Input.GetAxis("Horizontal");
        rigid.velocity = new Vector2(x*speed,rigid.velocity.y);
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




}
