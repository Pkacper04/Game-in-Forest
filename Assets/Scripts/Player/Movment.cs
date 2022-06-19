using UnityEngine;
using NaughtyAttributes;
using Game.SaveLoadSystem;

namespace Game.PlayerInfo
{
    public class Movment : MonoBehaviour
    {
        [SerializeField] private float speed = 8f;
        [SerializeField] private float jumpForce = 3.5f;
        [SerializeField] private float wallJumpForce = 7f;
        [SerializeField] private float onWallGravity;
        [SerializeField] private float slideDown;


        [SerializeField]
        private Rigidbody2D rigid;

        [SerializeField]
        private CapsuleCollider2D bodyCollider;

        [ShowNonSerializedField]
        private Transform lastTouchedObject;

        [ShowNonSerializedField]
        private bool isGrounded = false;
        [ShowNonSerializedField]
        private bool slide = false;
        [ShowNonSerializedField]
        private bool cheat = false;

        private bool onContact = false;
        private float blockMovement = 0;
        private Vector2 movingDirection;


        private void Start()
        {
            
            PlayerData data = SaveSystem.LoadPlayer();
            if (data != null)
                transform.position = new Vector2(data.positionX, data.positionY);
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.G))//delete leter only for tests
                cheat = !cheat;
            if (cheat)
                isGrounded = true;// delete leter only for tests

            Movement();
            if ((Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.W)))
                Jumping();
        }


        private void Movement()
        {
            float x = Input.GetAxis("Horizontal");

            if (rigid.velocity.y > Mathf.Max(wallJumpForce,jumpForce))
                rigid.velocity = new Vector2(rigid.velocity.x, jumpForce * 2f);

            movingDirection = new Vector2(x * speed, rigid.velocity.y);

            if (slide)
            {
                Sliding();
                return;
            }

            rigid.velocity = movingDirection;
        }


        private void Jumping()
        {
            if (isGrounded)
                rigid.AddForce(new Vector2(0, jumpForce));
            else if (slide)
            {
                if (blockMovement * movingDirection.x > 0)
                    return;
                rigid.velocity = movingDirection;
                rigid.AddForce(new Vector2(0, wallJumpForce));
            }

            isGrounded = false;
            slide = false;
        }

        private void Sliding()
        {
            if (rigid.velocity.y < 0)
                rigid.velocity = new Vector2(rigid.velocity.x, rigid.velocity.y * onWallGravity);

            if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            {
                rigid.velocity = new Vector2(rigid.velocity.x, rigid.velocity.y - slideDown);
            }
        }

        private void Animations()
        {
            //future animations
        }



        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (onContact)
                return;
            if (collision.otherCollider == bodyCollider)
                return;

            Debug.Log("enter collision");

            if (collision.gameObject.tag == "Ground")
            {
                lastTouchedObject = collision.gameObject.transform;
                isGrounded = true;
            }
            else if (collision.gameObject.tag == "JumpWall")
            {
                if(collision.transform.position.x > transform.position.x)
                    blockMovement = 1;
                else
                    blockMovement = -1;

                isGrounded = false;
                if (lastTouchedObject != collision.gameObject.transform)
                    slide = true;
                lastTouchedObject = collision.gameObject.transform;
            }

        }

        private void OnCollisionExit2D(Collision2D collision)
        {
            if (onContact)
                return;
            Debug.Log("exit collision");
            Debug.Log("exit collider: "+collision.otherCollider.name);
            if (collision.otherCollider == bodyCollider)
                return;
            blockMovement = 0;
            isGrounded = false;
            slide = false;
        }



        private void OnTriggerStay2D(Collider2D collision)
        {
            lastTouchedObject = collision.gameObject.transform;
            if (collision.gameObject.tag == "Ground")
            {
                onContact = true;
                isGrounded = true;
                slide = false;
                blockMovement = 0;
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            onContact = false;
        }


    }
}

