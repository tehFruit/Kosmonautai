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
    // The diameter within which the enemy should stop seeking the player y-wise.
    public float yRangeDiameter = 0.1f;
    public float bulletRange = 2;
    public float neededDistanceFromPlayer = 6;
    public float moveBackDistanceFromPlayer = 4;
    public Transform[] bullets_transforms = null;



    // Private variables:
    // True if player's y and enemy's y difference is less than rangeDiameter.
    bool withinRangeY;
    float moveHor;
    float moveVer;

    void Update(){
        // Array of bullet objects
        // GameObject[] bullets = GameObject.FindGameObjectsWithTag("Bullet");

        // // Array of those bullet object positions
        // bullets_transforms = new Transform[bullets.Length];

        // // Copy the positions of the bullets array into the positions array
        // if (bullets.Length != 0){
        // for(int i = 0; i < bullets.Length; i++){
        //     bullets_transforms[i] = bullets[i].transform;
        // }
        // } else{
        //     bullets_transforms = null;
        // }
    }

    void FixedUpdate()
    {
        // Array of bullet objects
        GameObject[] bullets = GameObject.FindGameObjectsWithTag("Bullet");

        // Array of those bullet object positions
        bullets_transforms = new Transform[bullets.Length];

        // Copy the positions of the bullets array into the positions array
        if (bullets.Length != 0){
        for(int i = 0; i < bullets.Length; i++){
            bullets_transforms[i] = bullets[i].transform;
        }
        } else{
            bullets_transforms = null;
        }
        // The current distance from player.
        float currDistFromPlayerX = calcDistanceX(new Vector2(player.position.x, player.position.y),
         new Vector2(transform.position.x, transform.position.y));
        // if (bullets_transforms != null){
        // if (GetClosestBullet(bullets_transforms).position.y >= transform.position.y){
        //     moveVer = -1;
        // }else{
        //     moveVer = 1;
        // }
        // }

        // Check if player is further than the y range diameter(y-wise).
        if (Mathf.Abs(player.position.y - transform.position.y) < yRangeDiameter){
            // Set that the enemy is within range y-wise(player y and enemy y coordinates are almost the same)
            withinRangeY = true;
            // Set the movement of the player only vertical.
            moveVer = 0;
            // rb.MovePosition(new Vector2(transform.position.x + moveHor,
            //      transform.position.y));
        }else{
            withinRangeY = false;
        }

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
                // rb.MovePosition(new Vector2(transform.position.x + moveHor,
                //  transform.position.y + (Mathf.Abs(player.position.y - transform.position.y) * movementSpeed)));
                //moveVer = (Mathf.Abs(player.position.y - transform.position.y) * movementSpeed);
                moveVer = movementSpeed;
            }else{
                // rb.MovePosition(new Vector2(transform.position.x + moveHor,
                //  transform.position.y - (Mathf.Abs(player.position.y - transform.position.y) * movementSpeed)));
                //moveVer = -(Mathf.Abs(player.position.y - transform.position.y) * movementSpeed);
                moveVer = -movementSpeed;
            }
        }

        if (bullets_transforms != null){
            if (Mathf.Abs(GetClosestBullet(bullets_transforms).position.y - transform.position.y) <= bulletRange && 
            Mathf.Abs(GetClosestBullet(bullets_transforms).position.x - transform.position.x) <= bulletRange * 2)
            {
                if (GetClosestBullet(bullets_transforms).position.y >= transform.position.y){
                    moveVer = -movementSpeed*1.5f;
                }else{
                    moveVer = movementSpeed*1.5f;
                }
            } else{
            }
        }

        // Always move the player, it's movement will depend on the values of moveHor and moveVer
        rb.MovePosition(new Vector2(transform.position.x + moveHor,
                 transform.position.y + moveVer));
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

    Transform GetClosestBullet(Transform[] bullets)
    {
        Transform tMin = null;
        float minDist = Mathf.Infinity;
        Vector3 currentPos = transform.position;
        foreach (Transform t in bullets){
            float dist = Vector3.Distance(t.position, currentPos);
            if (dist < minDist){
                tMin = t;
                minDist = dist;
            }
        }
        return tMin;
    }
}
