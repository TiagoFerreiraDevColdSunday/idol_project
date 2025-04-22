using UnityEngine;

public class PequenoCollector : Collector
{
    private bool isStretched = false;

    public void OnWordTapped()
    {
        Debug.Log("🖱️ TAP DETECTED!");

        if (wordCompleted && !isStretched)
        {
            Debug.Log("✅ Word is completed. Stretching now.");
            FindFirstObjectByType<StretchOnTap>().StretchPlayer();
            isStretched = true;
        }
        else if (wordCompleted && isStretched)
        {
            FindFirstObjectByType<StretchOnTap>().ResetStretch();
            isStretched = false;
        }
        else
        {
            Debug.Log("❌ Word is NOT completed yet.");
        }
    }

}
