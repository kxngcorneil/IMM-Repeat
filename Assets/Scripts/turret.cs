using UnityEditor;
using UnityEngine;

public class turret : MonoBehaviour
{
    public object bulletPrefab; 
    public Transform firePoint; 

    public float fireRate = 1f; 
    private float nextFireTime = 0f; 

    void Start()
    {
        // Initialize the turret if needed
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= nextFireTime)
        {
            Fire();
            nextFireTime = Time.time + fireRate;
        }
    }

    private void Fire()
    {
        if (bulletPrefab != null && firePoint != null)
        {
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        }
    }
}
