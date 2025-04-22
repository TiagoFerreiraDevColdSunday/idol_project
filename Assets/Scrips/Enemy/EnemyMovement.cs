using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 2f;
    public Transform groundCheck;
    public LayerMask groundLayer;
    private Vector3 originalScale;
    private Rigidbody2D rb;
    public Transform wallCheck;
    public LayerMask wallLayer;
    public float wallCheckDistance = 0.2f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        originalScale = transform.localScale;

    }

    void Update()
    {
        float direction = -Mathf.Sign(transform.localScale.x);
        rb.linearVelocity = new Vector2(direction * speed, rb.linearVelocity.y);

        // Ground detection (flip if no ground)
        RaycastHit2D groundInfo = Physics2D.Raycast(groundCheck.position, Vector2.down, 1.5f, groundLayer);

        // Wall detection (flip if wall ahead)
        Vector2 wallDirection = direction > 0 ? Vector2.left : Vector2.right;
        RaycastHit2D wallHit = Physics2D.Raycast(wallCheck.position, wallDirection, wallCheckDistance, wallLayer);
        Debug.DrawRay(wallCheck.position, wallDirection * wallCheckDistance, Color.green);

        if (!groundInfo.collider || wallHit.collider)
        {
            Flip();
        }
    }


    void Flip()
    {
        transform.localScale = new Vector3(
            originalScale.x * -Mathf.Sign(transform.localScale.x),
            originalScale.y,
            originalScale.z
        );
    }

}
