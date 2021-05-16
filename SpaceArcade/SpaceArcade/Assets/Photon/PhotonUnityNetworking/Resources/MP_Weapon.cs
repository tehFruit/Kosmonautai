 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class MP_Weapon : MonoBehaviour
{

    public Transform firePoint;
    public GameObject bulletPrefab;
    public float fireRate = 15f;
    private float nextTimeToFire = 0f;
    PhotonView photon;

    void Start()
    {
        photon = GetComponent<PhotonView>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!photon.IsMine) return;
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
        GameObject impactGo = PhotonNetwork.Instantiate(bulletPrefab.name, firePoint.position, firePoint.rotation);
        Destroy(impactGo, 2f);
    }
}
