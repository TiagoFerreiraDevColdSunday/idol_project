using UnityEngine;

public class BossShooter : MonoBehaviour
{
    public GameObject fireballPrefab;
    public Transform firePoint;
    public float fireRate = 10f;
    private float nextFireTime;

    public Vector2 shootDirection = Vector2.left;

    void Update()
    {
        if (Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + fireRate;
        }
    }

    void Shoot()
    {
        GameObject fireball = Instantiate(fireballPrefab, firePoint.position, Quaternion.identity);
        Fireball fb = fireball.GetComponent<Fireball>();
        fb.direction = shootDirection;
    }
}
