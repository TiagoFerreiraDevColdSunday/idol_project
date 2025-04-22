using UnityEngine;

public class BarrierOnTap : MonoBehaviour
{
    private BarreiraCollector wordCollector;
    public GameObject barrierObject;
    public float barrierDuration = 5f; // seconds
    public float barrierCooldown = 10f; // seconds
    private float timer = 0f; // seconds
    private bool barrierActive = false;
    private float lastActivatedTime = -Mathf.Infinity;


    void Start()
    {
        barrierObject.SetActive(false);
        wordCollector = FindFirstObjectByType<BarreiraCollector>();
    }

    void Update()
    {

        if (barrierActive)
        {
            timer -= Time.deltaTime;
            if (timer <= 0f)
            {
                DeactivateBarrier();
            }
        }

        if (wordCollector != null && wordCollector.wordCompleted)
        {
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
            {
                ActivateBarrier();
            }
        }
    }

    public void ActivateBarrier()
    {
        if (Time.time - lastActivatedTime < barrierCooldown)
        {
            Debug.Log("🕒 Barrier is on cooldown.");
            return;
        }

        Debug.Log("🟢 Activating Barrier!");

        if (barrierObject != null)
        {
            barrierObject.SetActive(true);
            timer = barrierDuration;
            lastActivatedTime = Time.time;
            barrierActive = true;
            barrierObject.transform.position = transform.position;
        }
    }

    public void DeactivateBarrier()
    {
        Debug.Log("🔴 Deactivating Barrier.");
        barrierObject.SetActive(false);
        barrierActive = false;
    }
}