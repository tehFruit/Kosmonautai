using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWaveController : MonoBehaviour
{
    public GameObject stupidEnemyPrefab;    // Stupid enemy game object.
    public GameObject cleverEnemyPrefab;    // Clever enemy game object.      
    public int waveNumber;                  // Which wave is the current one.
    public bool stupidWave = false;         // Whether the wave contains only stupid enemies.
    public float respawnTime = 1.0f;
    private GameObject[] allEnemies;
    public Vector3 scrBound;

    void Start(){
        // Set the wave to the first one.
        waveNumber = 0;
        scrBound = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    void Update(){
        allEnemies = GameObject.FindGameObjectsWithTag("Enemy");
        if (allEnemies.Length == 0){
            spawnWave();
        }
    }

    private void spawnWave(){
        waveNumber++;
            if (waveNumber == 1){
                // Enemy 1:
                GameObject enemy1 = Instantiate(stupidEnemyPrefab) as GameObject;
                StupidEnemyBehaviour about_enemy1 = enemy1.GetComponent<StupidEnemyBehaviour>();
                enemy1.transform.position = new Vector2(15, - scrBound.y / 2);

                // Enemy 2:
                GameObject enemy2 = Instantiate(stupidEnemyPrefab) as GameObject;
                StupidEnemyBehaviour about_enemy2 = enemy2.GetComponent<StupidEnemyBehaviour>();
                enemy2.transform.position = new Vector2(15, scrBound.y / 2);
            }

            if (waveNumber == 2){
                // Enemy 1:
                GameObject enemy1 = Instantiate(stupidEnemyPrefab) as GameObject;
                StupidEnemyBehaviour about_enemy1 = enemy1.GetComponent<StupidEnemyBehaviour>();
                enemy1.transform.position = new Vector2(15, - scrBound.y / 2);

                // Enemy 2:
                GameObject enemy2 = Instantiate(stupidEnemyPrefab) as GameObject;
                StupidEnemyBehaviour about_enemy2 = enemy2.GetComponent<StupidEnemyBehaviour>();
                about_enemy2.maximumApproach = 5;
                enemy2.transform.position = new Vector2(15, 0);

                // Enemy 3:
                GameObject enemy3 = Instantiate(stupidEnemyPrefab) as GameObject;
                StupidEnemyBehaviour about_enemy3 = enemy2.GetComponent<StupidEnemyBehaviour>();
                enemy3.transform.position = new Vector2(15, scrBound.y / 2);
            }

            if (waveNumber == 3){
                // Enemy 1:
                GameObject enemy1 = Instantiate(stupidEnemyPrefab) as GameObject;
                StupidEnemyBehaviour about_enemy1 = enemy1.GetComponent<StupidEnemyBehaviour>();
                enemy1.transform.position = new Vector2(15, - scrBound.y / 2);

                // Enemy 2:
                GameObject enemy2 = Instantiate(stupidEnemyPrefab) as GameObject;
                StupidEnemyBehaviour about_enemy2 = enemy2.GetComponent<StupidEnemyBehaviour>();
                enemy2.transform.position = new Vector2(15, 0);

                // Enemy 3:
                GameObject enemy3 = Instantiate(stupidEnemyPrefab) as GameObject;
                StupidEnemyBehaviour about_enemy3 = enemy2.GetComponent<StupidEnemyBehaviour>();
                enemy3.transform.position = new Vector2(15, scrBound.y / 2);

                // Enemy 4:
                GameObject enemy4 = Instantiate(stupidEnemyPrefab) as GameObject;
                StupidEnemyBehaviour about_enemy4 = enemy4.GetComponent<StupidEnemyBehaviour>();
                about_enemy4.maximumApproach = 5;
                enemy4.transform.position = new Vector2(15, - scrBound.y / 2 + 1);

                // Enemy 5:
                GameObject enemy5 = Instantiate(stupidEnemyPrefab) as GameObject;
                StupidEnemyBehaviour about_enemy5 = enemy5.GetComponent<StupidEnemyBehaviour>();
                about_enemy5.maximumApproach = 5;
                enemy5.transform.position = new Vector2(15, 0 + 1);

                // Enemy 6:
                GameObject enemy6 = Instantiate(stupidEnemyPrefab) as GameObject;
                StupidEnemyBehaviour about_enemy6 = enemy6.GetComponent<StupidEnemyBehaviour>();
                about_enemy6.maximumApproach = 5;
                enemy6.transform.position = new Vector2(15, scrBound.y / 2 + 1);

                // Enemy 7:
                GameObject enemy7 = Instantiate(stupidEnemyPrefab) as GameObject;
                StupidEnemyBehaviour about_enemy7 = enemy7.GetComponent<StupidEnemyBehaviour>();
                about_enemy7.maximumApproach = 5;
                enemy7.transform.position = new Vector2(15, - scrBound.y / 2 - 1);
            }

            if (waveNumber == 4){
                // Enemy 1:
                GameObject enemy1 = Instantiate(cleverEnemyPrefab) as GameObject;
                enemy1.transform.position = new Vector2(15, 0);
            }
        }
}
