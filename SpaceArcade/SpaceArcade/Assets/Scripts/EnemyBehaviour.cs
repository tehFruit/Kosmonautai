using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    // Public variables:
    // To know the player's position.
    public Transform player;
    // Movement speed.
    public float movementSpeed = 0.05f;
    public Rigidbody2D rb;
    // The diameter within which the enemy should stop seeking the player.
    public float rangeDiameter = 0.1f;


    // Private variables:
    // True if player's y and enemy's y difference is less than rangeDiameter.
    bool withinRangeY;

    void FixedUpdate()
    {
        // Check if player is further than the range diameter(y-wise).
        if (Mathf.Abs(player.position.y - transform.position.y) < rangeDiameter){
            withinRangeY = true;
        }else{
            withinRangeY = false;
        }

        // If the player is notwithin range, then seek him(y-wise).
        if (!withinRangeY){
            if (transform.position.y < player.position.y){
                rb.MovePosition(new Vector2(transform.position.x, transform.position.y + (Mathf.Abs(player.position.y - transform.position.y) * movementSpeed)));
            }else{
                rb.MovePosition(new Vector2(transform.position.x, transform.position.y - (Mathf.Abs(player.position.y - transform.position.y) * movementSpeed)));
            }
        }
    }
}
