using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    // Public variables:
    public Transform player;                        // The player's position.
    // Movement speed.
    public float movementSpeed = 0.02f;             // The overall movement speed of this enemy object.
    public Rigidbody2D rb;                          // Rigidbody component of this enemy object.
    public float yRangeDiameter = 0.1f;             // The diameter within which the enemy should stop seeking the player y-wise.

    public float bulletRange = 2;                   // The maximum range to move away from a bullet. 
    public float neededDistanceFromPlayer = 6;      // The distance at which to stop seeking the player x-wise.
    public float moveBackDistanceFromPlayer = 4;    // The distance at which to start move away from player x-wise.
    public Transform[] bullets_transforms = null;   // Array of all current bullet positions in the game.



    // Private variables:
    bool withinRangeY;  // True if player's y and enemy's y difference is less than yRangeDiameter.
    float moveHor;      // Horizontal moving speed.
    float moveVer;      // Vertical moving speed.



    void Start(){
        // Fetch the player position's component. 
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void FixedUpdate()
    {
        // Array of bullet objects
        GameObject[] bullets = GameObject.FindGameObjectsWithTag("Bullet");

        // Array of those bullet object positions
        bullets_transforms = new Transform[bullets.Length];

        // Preparing the bullets_transforms array logic.
        // Copy the positions of the bullets array into the positions array
        if (bullets.Length != 0){
        for(int i = 0; i < bullets.Length; i++){
            bullets_transforms[i] = bullets[i].transform;
        }
        }else{
            bullets_transforms = null;
        }

        // The current distance from player x-wise.
        float currDistFromPlayerX = calcDistanceX(new Vector2(player.position.x, player.position.y),
         new Vector2(transform.position.x, transform.position.y));

        // Enemy seeking the player y-wise logic.
        // Check if player is further than the yRangeDiameter.
        if (Mathf.Abs(player.position.y - transform.position.y) < yRangeDiameter){
            // Set that the enemy is within range y-wise(player y and enemy y coordinates are almost the same)
            withinRangeY = true;
        }else{
            // Else if the player is further than yRangeDiameter y-wise, then set that this enemy object is not within range y-wise.
            withinRangeY = false;
        }

        // Enemy seeking the player x-wise if the current x distance from player is negative logic.
        // If the the current distance from player x-wise is negative:
        if (currDistFromPlayerX <= 0){
            // If the absolute value of the current distance from player x-wise is less than the move back distance:
            if (Mathf.Abs(currDistFromPlayerX) < moveBackDistanceFromPlayer){
                // Let this enemy object move right.
                moveHor = movementSpeed;
            // Else if the absolute value of the current distance from player x-wise is greater than the needed distance from player:
            } else  if (Mathf.Abs(currDistFromPlayerX) > neededDistanceFromPlayer){
                // Let this enemy object move left.
                moveHor = -movementSpeed;
            // Else means the enemy is at the right distance to stay in place against the player:
            } else {
                // So set the horizontal speed to 0.
                moveHor = 0;
            }
        }

        // Enemy seeking the player x-wise if the current x distance from player is positive logic.
        // If the the current distance from player x-wise is positive:
        if (currDistFromPlayerX > 0){
            // If the absolute value of the current distance from player x-wise is less than the move back distance:
            if (Mathf.Abs(currDistFromPlayerX) < moveBackDistanceFromPlayer){
                // Let this enemy object move left.
                moveHor = -movementSpeed;
            // Else if the absolute value of the current distance from player x-wise is greater than the needed distance from player:
            } else  if (Mathf.Abs(currDistFromPlayerX) > neededDistanceFromPlayer){
                // Let this enemy object move right.
                moveHor = movementSpeed;
            // Else means the enemy is at the right distance to stay in place against the player:
            } else{
                // So set the horizontal speed to 0.
                moveHor = 0;
            }
        }

        // Setting the vertical speed of the enemy logic.
        // If the player is not within range(y-wise).
        if (!withinRangeY){
            // If the player is above
            if (transform.position.y < player.position.y){
                // Let the enemy object move up.
                moveVer = movementSpeed;
            // Else if the player is below
            }else{
                // Let the enemy object move down.
                moveVer = -movementSpeed;
            }
        // Else if the enemy is within range(y-wise).
        }else{
            // Set the enemy object speed to 0.
            moveVer = 0;
        }

        // Enemy avoiding bullets logic.
        // If there are bullets currently in the game:
        if (bullets_transforms != null){
            // Getting the closest bullet:
            Transform closestBullet = GetClosestBullet(bullets_transforms);
            // If the closest bullet is closer than bulletRange y-wise and closer than bulletRange*2 x-wise:
            if (Mathf.Abs(closestBullet.position.y - transform.position.y) <= bulletRange && 
            Mathf.Abs(closestBullet.position.x - transform.position.x) <= bulletRange * 2)
            {
                // If the closest bullet is above:
                if (closestBullet.position.y >= transform.position.y){
                    // Let the enemy object move down.
                    moveVer = -movementSpeed*1.2f;
                // Else if the closest bullet is below:
                }else{
                    // Let the enemy object move up.
                    moveVer = movementSpeed*1.2f;
                }
            }
        }

        // Always move the player, it's movement will depend on the values of moveHor and moveVer
        rb.MovePosition(new Vector2(transform.position.x + moveHor,
                 transform.position.y + moveVer));
    }


    // Function: Calculates the distance between object a and b.
    float calcDistance(Vector2 a, Vector2 b){
        float dist = 0;

        dist = Mathf.Sqrt(Mathf.Pow(Mathf.Abs(a.x - b.x), 2) + Mathf.Pow(Mathf.Abs(a.y - b.y), 2));

        return dist;
    }

    // Function: Calculates the x distance between object a and b.
    float calcDistanceX(Vector2 a, Vector2 b){
        float dist = 0;
        dist = a.x - b.x;
        return dist;
    }

    // Function: Gets the closest bullet.
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
