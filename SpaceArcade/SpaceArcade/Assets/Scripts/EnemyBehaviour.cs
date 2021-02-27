using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    // Public variables:
    // To know the player's position.
    public Transform player;
    // Movement speed.
    public float movementSpeed = 0.02f;
    public Rigidbody2D rb;
    // The diameter within which the enemy should stop seeking the player.
    public float rangeDiameter = 0.1f;
    public float neededDistanceFromPlayer = 6;
    public float moveBackDistanceFromPlayer = 4;


    // Private variables:
    // True if player's y and enemy's y difference is less than rangeDiameter.
    bool withinRangeY;
    float moveHor;

    void FixedUpdate()
    {
        // The current distance from player.
        float currDistFromPlayerX = calcDistanceX(new Vector2(player.position.x, player.position.y),
         new Vector2(transform.position.x, transform.position.y));

        // Check if player is further than the range diameter(y-wise).
        if (Mathf.Abs(player.position.y - transform.position.y) < rangeDiameter){
            withinRangeY = true;
            rb.MovePosition(new Vector2(transform.position.x + moveHor,
                 transform.position.y));
        }else{
            withinRangeY = false;
        }

        Debug.Log(Mathf.Abs(currDistFromPlayerX) + " < " + moveBackDistanceFromPlayer);  
        Debug.Log(Mathf.Abs(currDistFromPlayerX) + " > " + neededDistanceFromPlayer);  
        if (currDistFromPlayerX <= 0){
            if (Mathf.Abs(currDistFromPlayerX) < moveBackDistanceFromPlayer){
                moveHor = movementSpeed;
            } else  if (Mathf.Abs(currDistFromPlayerX) > neededDistanceFromPlayer){
                moveHor = -movementSpeed;
            } else {
                moveHor = 0;
            }
        }
        if (currDistFromPlayerX > 0){
            if (Mathf.Abs(currDistFromPlayerX) < moveBackDistanceFromPlayer){
                moveHor = -movementSpeed;
            } else  if (Mathf.Abs(currDistFromPlayerX) > neededDistanceFromPlayer){
                moveHor = movementSpeed;
            } else{
                moveHor = 0;
            }
        }

        // If the player is not within range, then seek him(y-wise).
        if (!withinRangeY){
            if (transform.position.y < player.position.y){
                rb.MovePosition(new Vector2(transform.position.x + moveHor,
                 transform.position.y + (Mathf.Abs(player.position.y - transform.position.y) * movementSpeed)));
            }else{
                rb.MovePosition(new Vector2(transform.position.x + moveHor,
                 transform.position.y - (Mathf.Abs(player.position.y - transform.position.y) * movementSpeed)));
            }
        }
    }

    // Calculates the distance between object a and b.
    float calcDistance(Vector2 a, Vector2 b){
        float dist = 0;

        dist = Mathf.Sqrt(Mathf.Pow(Mathf.Abs(a.x - b.x), 2) + Mathf.Pow(Mathf.Abs(a.y - b.y), 2));

        return dist;
    }

    float calcDistanceX(Vector2 a, Vector2 b){
        float dist = 0;

        dist = a.x - b.x;

        return dist;
    }
}
