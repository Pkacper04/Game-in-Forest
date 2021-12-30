using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class Movment : MonoBehaviour
    {
        [SerializeField] private float speed = 8f;
        [SerializeField] private float jumpForce = 3.5f;


        
        private Rigidbody2D rigid;
        private Transform lastTouchedObject;

        private bool isGrounded = false;
        private bool slide = false;
        private bool cheat = false;

        void Start()
        {
            rigid = GetComponent<Rigidbody2D>();
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.G))//delete leter only for tests
            {
                cheat = !cheat;
            }

            if(cheat)
            {
                isGrounded = true;// delete leter only for tests
            }

            if(slide)
            {
                rigid.velocity = new Vector2(rigid.velocity.x, -jumpForce + jumpForce/2);
            }

            Movement();
            if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W)))
                Jump();
        }


        private void Movement()
        {
            float x = Input.GetAxis("Horizontal");
            rigid.velocity = new Vector2(x * speed, rigid.velocity.y);

            if (rigid.velocity.y > jumpForce * 2f)
                rigid.velocity = new Vector2(rigid.velocity.x, jumpForce * 2f);
        }
        

        private void Jump()
        {
            if (isGrounded)
            {
                if(slide)
                    rigid.AddForce(new Vector2(0, jumpForce*2f));
                else
                    rigid.AddForce(new Vector2(0, jumpForce));
                isGrounded = false;
                slide = false;
            }
        }

        private void Animations()
        {
            //future animations
        }


        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag == "Ground")
            {
                lastTouchedObject = collision.gameObject.transform;
                isGrounded = true;
            }
            else if (collision.gameObject.tag == "JumpWall")
            {
                slide = true;
                if (lastTouchedObject != collision.gameObject.transform)
                    isGrounded = true;
                lastTouchedObject = collision.gameObject.transform;
            }

        }

        private void OnCollisionExit2D(Collision2D collision)
        {
            isGrounded = false;
            slide = false;
        }

        private void OnCollisionStay2D(Collision2D collision)
        {
            if (collision.gameObject.tag == "Ground")
                isGrounded = true;
        }





    }
}
