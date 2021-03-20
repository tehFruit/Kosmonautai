using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageController : MonoBehaviour
{
    public int health;
    public int numberOfHearts;

    float invulnerabilityTimer = 0;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    int initialLayer;

    int score = 0;
    public Text scoreText;

    public SpriteRenderer sprite;
 
    void Start()
    {
        initialLayer = gameObject.layer;
    }

    /// <summary>
    ///  Whenever a collison accurs health is depleted and invulnerability timer is started
    /// </summary>
    /// <param name="obj">The other colliding object</param>
    void OnTriggerEnter2D(Collider2D obj)
    {
        // If enemy does not die
        /*if (obj.gameObject.tag == "Enemy")
            health--;*/

        if(obj.gameObject.tag == "Bullet")
        {
            Destroy(obj.gameObject);
        }

        health--;
        StartCoroutine(FlashRed());
        
        invulnerabilityTimer = 0.5f;
        gameObject.layer = 6;
    }

    void Update()
    {
        // Sets the health so that it would not excede numberOfHearts
        if (health > numberOfHearts)
            health = numberOfHearts;
       
        if (gameObject.tag == "Player")
        {
            for (int i = 0; i < hearts.Length; i++)
            {
                // Sets the health hearts to empty of full
                if (i < health)
                    hearts[i].sprite = fullHeart;
                else
                    hearts[i].sprite = emptyHeart;

                // Makes sure that the displayed hearts do not excede numberOfHearts
                if (i < numberOfHearts)
                    hearts[i].enabled = true;
                else
                    hearts[i].enabled = false;
            }
        }

        // When the invulnerabilityTimer runs out the layer is set back to the initial one
        invulnerabilityTimer -= Time.deltaTime;
        if (invulnerabilityTimer <= 0)
            gameObject.layer = initialLayer;

        if (health <= 0)
            Die();
    }

    /// <summary>
    /// Destroys the object and updates the score
    /// </summary>
    void Die()
    {
        if (gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
            score++;
            scoreText.text = score.ToString();
        }
            

        if (gameObject.tag == "Player")
            Debug.Log("Death"); // Death screen goes here
    }

    public IEnumerator FlashRed()
    {
        sprite.color = Color.red;
        yield return new WaitForSeconds(0.2f);
        sprite.color = Color.white;
    }
}
