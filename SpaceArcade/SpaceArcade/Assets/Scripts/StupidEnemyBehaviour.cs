using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StupidEnemyBehaviour : MonoBehaviour
{
    public Rigidbody2D rb;
    float moveHor;
    float moveVer;
    public float moveSpeed = 0.05f;
    
    void FixedUpdate(){
        if (transform.position.x > 7){
            moveHor = -moveSpeed;
        }
        else{
            moveHor = 0;
        }
        rb.MovePosition(new Vector2(transform.position.x + moveHor, transform.position.y + moveVer));
    }
}
