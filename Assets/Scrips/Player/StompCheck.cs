using UnityEngine;

public class StompEnemy : MonoBehaviour
{
    public float bounceForce = 7f;

    public int damageToTheBoss = 1;

    private BossHealth bossHealth;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy") || collision.CompareTag("Boss"))
        {
            // Destroy enemy
            if (collision.CompareTag("Enemy"))
                Destroy(collision.gameObject);

            // Deal damage to boss
            if (collision.CompareTag("Boss"))
            {
                bossHealth = collision.GetComponent<BossHealth>();
                if (bossHealth != null)
                {
                    bossHealth.TakeDamage(damageToTheBoss);
                }
            }

            // Bounce the player
            Rigidbody2D rb = GetComponentInParent<Rigidbody2D>();
            if (rb != null)
            {
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, bounceForce);
            }
        }
    }
}
