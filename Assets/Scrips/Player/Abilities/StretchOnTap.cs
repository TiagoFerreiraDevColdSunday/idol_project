using UnityEngine;

public class StretchOnTap : MonoBehaviour
{
    private PequenoCollector wordCollector;
    private Vector3 originalScale;
    public float stretchAmount = 0.5f;

    void Start()
    {
        wordCollector = FindFirstObjectByType<PequenoCollector>();
        originalScale = transform.localScale;
    }

    void Update()
    {
        if (wordCollector != null && wordCollector.wordCompleted)
        {
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
            {
                StretchPlayer();
            }
        }
    }

    public void StretchPlayer()
    {
        transform.localScale = new Vector3(originalScale.x, originalScale.y * stretchAmount, originalScale.z);
        Debug.Log("🧍 Player stretched!");
    }

    public void ResetStretch()
    {
        transform.localScale = originalScale;
        Debug.Log("🔄 Player reset to original scale.");
    }
}
