using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_weapon : MonoBehaviour
{

    public Transform firePoint;
    public float range;
    private float distToPlayer;
    public int bulletSpeed;


    public GameObject bulletPrefab2;

    public float fireRate, timeBTWshoots;
    private float nextTimeToFire = 2f;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + Random.Range(fireRate, fireRate + 1);
            StartCoroutine(Shoot());
        }

        //distToPlayer = Vector2.Distance(transform.position, player.position);
        

    }

    IEnumerator Shoot()
    {
        yield return new WaitForSeconds(timeBTWshoots);
        GameObject bullet2 = Instantiate(bulletPrefab2, 
            new Vector3(firePoint.position.x - 1.2f, firePoint.position.y, firePoint.position.z), 
            new Quaternion(0,0,1,0));
        bullet2 about_bullet2 = bullet2.GetComponent<bullet2>();
        about_bullet2.speed = Random.Range(bulletSpeed, bulletSpeed + 2);
        //Destroy(bullet2, 2f);
      //  bullet2.GetComponent<Rigidbody2D>().velocity = new Vector2 
    }
}
