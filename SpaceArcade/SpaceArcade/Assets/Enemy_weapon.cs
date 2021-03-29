using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_weapon : MonoBehaviour
{

    public Transform firePoint;
    public float range;
    private float distToPlayer;



    public GameObject bulletPrefab2;

    public float fireRate = 10f, timeBTWshoots;
    private float nextTimeToFire = 3f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 4f / fireRate;
            StartCoroutine(Shoot());
        }

        //distToPlayer = Vector2.Distance(transform.position, player.position);
        

    }

    IEnumerator Shoot()
    {
        yield return new WaitForSeconds(timeBTWshoots);
        GameObject bullet2 = Instantiate(bulletPrefab2, firePoint.position, firePoint.rotation);
        Destroy(bullet2, 2f);
      //  bullet2.GetComponent<Rigidbody2D>().velocity = new Vector2 
    }
}
