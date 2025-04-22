using UnityEngine;
using UnityEngine.SceneManagement;

public class StarCollision : MonoBehaviour
{
    public string nextSceneName;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("🌟 Player touched Star Light! Loading next scene...");
            SceneManager.LoadScene(nextSceneName);
        }
    }
}
