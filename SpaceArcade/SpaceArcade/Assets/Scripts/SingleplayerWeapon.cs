using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class SingleplayerWeapon : MonoBehaviour
{

    public Transform firePoint;
    public GameObject bulletPrefab;
    public float fireRate = 15f;
    private float nextTimeToFire = 0f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 4f / fireRate;
            SoundScript.PlaySound("fire");
            Shoot();
        }

    }

    void Shoot()
    {
        //shooting logic
        GameObject impactGo = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Destroy(impactGo, 2f);
    }
}
