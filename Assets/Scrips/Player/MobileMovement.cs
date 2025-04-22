using UnityEngine;

public class MobilePlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 10f;
    private int moveDirection = 0;
    private int numberOfJumps = 0;
    private Rigidbody2D rb;
    private bool isOnTheGround = true;
    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(moveDirection * speed * Time.deltaTime, 0f, 0f);
    }

    public void MoveLeft()
    {
        anim.SetBool("isWalking", true);
        moveDirection = -1;
    }

    public void MoveRight()
    {
        anim.SetBool("isWalking", true);
        moveDirection = 1;
    }

    public void Stop()
    {
        anim.SetBool("isWalking", false);
        moveDirection = 0;
    }

    public void Jump()
    {
        if (isOnTheGround || numberOfJumps < 2)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            isOnTheGround = false;
            numberOfJumps++;
            anim.SetBool("isJumping", true);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.contacts[0].normal.y > 0.5f)
        {
            numberOfJumps = 0;
            isOnTheGround = true;
            anim.SetBool("isJumping", false);
        }
    }
}
