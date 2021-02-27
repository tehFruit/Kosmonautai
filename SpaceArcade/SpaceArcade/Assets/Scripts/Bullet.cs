using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float speed = 20f;
    public Rigidbody2D rb;
    public int damage = 10;
    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
    }
   

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

}
