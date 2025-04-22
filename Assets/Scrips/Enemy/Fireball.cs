using UnityEngine;

public class Fireball : MonoBehaviour
{
    public float speed = 1f;
    public float lifetime = 5f;
    public Vector2 direction = Vector2.left;

    private Rigidbody2D rb;

    private PlayerHealth playerHealth;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.linearVelocity = direction.normalized * speed;

        Destroy(gameObject, lifetime); // auto-destroy
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerHealth = collision.GetComponent<PlayerHealth>();
            
            playerHealth.takeDamage();
            Debug.Log("🔥 Fireball hit the player!");
            Destroy(gameObject);
        }

        // You can also add wall collision logic here if needed
        if (collision.CompareTag("Platform")) {
            Destroy(gameObject);
        }
    }
}
