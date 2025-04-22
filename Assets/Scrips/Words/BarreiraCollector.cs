using UnityEngine;

public class BarreiraCollector : Collector
{
    private bool hasBarrier = false;

    public void OnWordTapped()
    {
        Debug.Log("🖱️ TAP DETECTED!");

        if (wordCompleted && !hasBarrier)
        {
            Debug.Log("✅ Word is completed. Adding barrier now.");
            FindFirstObjectByType<BarrierOnTap>().ActivateBarrier();
            hasBarrier = true;
        }
        else if (wordCompleted && hasBarrier)
        {
            FindFirstObjectByType<BarrierOnTap>().DeactivateBarrier();
            hasBarrier = false;
        }
        else
        {
            Debug.Log("❌ Word is NOT completed yet.");
        }
    }

}