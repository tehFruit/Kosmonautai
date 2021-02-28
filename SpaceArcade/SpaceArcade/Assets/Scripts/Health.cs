using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public int health;
    public int numberOfHearts;

    float invulnerabilityTimer = 0;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    int initialLayer;

    void Start()
    {
        initialLayer = gameObject.layer;
    }

    void OnTriggerEnter2D(Collider2D obj)
    {
        // If enemy does not die
        if (obj.gameObject.tag == "Enemy")
            health--;

        //health--; Enemy also dies

        invulnerabilityTimer = 0.5f;
        gameObject.layer = 6;
    }

    void Update()
    {
        if (health > numberOfHearts)
            health = numberOfHearts;

        if (gameObject.tag == "Player")
        {
            for (int i = 0; i < hearts.Length; i++)
            {
                if (i < health)
                    hearts[i].sprite = fullHeart;
                else
                    hearts[i].sprite = emptyHeart;

                if (i < numberOfHearts)
                    hearts[i].enabled = true;
                else
                    hearts[i].enabled = false;
            }
        }

        invulnerabilityTimer -= Time.deltaTime;
        if (invulnerabilityTimer <= 0)
            gameObject.layer = initialLayer;

        if (health <= 0)
            Die();
    }

    void Die()
    {
        if (gameObject.tag == "Enemy")
            Destroy(gameObject);

        if (gameObject.tag == "Player")
            Debug.Log("Death"); // Death screen goes here
    }
}
