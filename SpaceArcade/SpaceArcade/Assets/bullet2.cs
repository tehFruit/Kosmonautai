using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet2 : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // rb.velocity = transform.right * speed;
        rb.velocity = new Vector2(-speed, 0);
    }

    void OnCollisionEnter(Collision Other)
    {
        Destroy(this.gameObject);
    }
    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

}
