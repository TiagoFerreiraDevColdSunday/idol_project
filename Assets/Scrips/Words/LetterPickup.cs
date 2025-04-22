using UnityEngine;

public class LetterPickup : MonoBehaviour
{
    public char letter;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Collector collector = other.GetComponent<Collector>();

            if (collector != null)
            {
                collector.CollectLetter(letter);
                Destroy(gameObject);
            }
        }
    }
}