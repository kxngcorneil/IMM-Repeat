using UnityEditor;
using UnityEngine;

public class turret : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] public Transform firePoint;

    [SerializeField] private float fireRate = 1f;
    private float nextFireTime = 0f;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        // If Time.time (the time since the game started) is greater than or equal to nextFireTime, then fire.
        // Time is then added to nextFireTime to ensure a delay between shots.
        if (Time.time >= nextFireTime)
        {
            Fire();
            nextFireTime = Time.time + fireRate;
        }
    }

    private void Fire()
    {
        if (bulletPrefab == null)
        {
            Debug.LogError("Bullet Prefab is not assigned in the Inspector!");
            return;
        }

        if (firePoint == null)
        {
            Debug.LogError("Fire Point is not assigned in the Inspector!");
            return;
        }

        // Creates the bullet prefab
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}