using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxLives = 3;
    private int currentLives;

    public LayerMask enemyLayer;

    public TextMeshProUGUI livesText;

    public Image[] hearts;

    public int imortalityAfterHitTime = 3; // seconds

    private float invincibilityTimer = 0f;

    public float fallThreshold = -10f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentLives = maxLives;
        livesText.text = "Current Lives: " + currentLives;
    }

    void Update()
    {
        // Reduce the invincibility timer over time
        if (invincibilityTimer > 0)
        {
            invincibilityTimer -= Time.deltaTime;
        }

        if (transform.position.y < fallThreshold)
        {
            Debug.Log("Player fell. Restarting scene...");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the player is colliding with an enemy and is not invincible
        if ((collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Projectile")) && invincibilityTimer <= 0)
        {
            Debug.Log("Player hit by enemy!");
            takeDamage();
            invincibilityTimer = imortalityAfterHitTime;
        }
    }

    // When damage is taken
    public void takeDamage()
    {
        currentLives--;
        UpdateUI();

        if (currentLives <= 0)
        {
            dies();
        }
    }

    void UpdateUI()
    {
        livesText.text = "Lives: " + currentLives;

        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < currentLives)
                hearts[i].enabled = true;  // show heart
            else
                hearts[i].enabled = false; // hide heart
        }
    }

    // When player is very dead!
    public void dies()
    {
        Debug.Log("Player died!");
        // Reload current scene or load Game Over screen
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
