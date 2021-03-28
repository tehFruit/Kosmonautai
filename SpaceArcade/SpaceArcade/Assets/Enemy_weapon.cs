using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_weapon : MonoBehaviour
{

    public Transform firePoint;
    public GameObject bulletPrefab2;

    public float fireRate = 15f;
    private float nextTimeToFire = 10f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 2.5f / fireRate;
            Shoot();
        }

    }

    void Shoot()
    {
        GameObject bullet2 = Instantiate(bulletPrefab2, firePoint.position, firePoint.rotation);
        Destroy(bullet2, 2f);
    }
}
