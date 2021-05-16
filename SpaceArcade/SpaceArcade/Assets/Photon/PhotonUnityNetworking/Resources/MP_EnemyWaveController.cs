using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class MP_EnemyWaveController : MonoBehaviour
{
    public GameObject stupidEnemyPrefab;    // Stupid enemy game object.
    public GameObject cleverEnemyPrefab;    // Clever enemy game object.      
    public int waveNumber;                  // Wave number.
    private GameObject[] allEnemies;
    public Vector3 scrBound;

    void Start(){
        scrBound = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    void Update(){
        allEnemies = GameObject.FindGameObjectsWithTag("Enemy");
        if (allEnemies.Length == 0 && PhotonNetwork.IsMasterClient){
            spawnWave();
        }
    }

    private void spawnWave(){
        // How many lines of enemies there will be.
        int waveWidth;

        // If the wave number is from 0 to 3, then it spawns a lot
        // of stupid enemies, else it spawns the clever enemy.
        waveNumber = Random.Range(0, 5);

        if (waveNumber == 4){
            // Spawn a clever enemy:
            PhotonNetwork.Instantiate(cleverEnemyPrefab.name, new Vector2(15, 0), cleverEnemyPrefab.transform.rotation);

            //GameObject enemy = Instantiate(cleverEnemyPrefab) as GameObject;
            //enemy.transform.position = new Vector2(15, 0);
        }
        else{
            waveWidth = Random.Range(2, 6);
            for (int i = 1; i <= waveWidth; i++){
                for (int j = 1; j <= i; j++){
                    // Spawn a stupid enemy:
                    GameObject enemy = PhotonNetwork.Instantiate(stupidEnemyPrefab.name, new Vector2(15, scrBound.y - ((scrBound.y / (i + 1)) * j * 2)), stupidEnemyPrefab.transform.rotation);

                   //GameObject enemy = Instantiate(stupidEnemyPrefab) as GameObject;
                   StupidEnemyBehaviour about_enemy = enemy.GetComponent<StupidEnemyBehaviour>();
                   //enemy.transform.position = new Vector2(15, scrBound.y - ((scrBound.y / (i + 1)) * j * 2));
                   about_enemy.maximumApproach = 1 + i * 1.5f;
                }
            }
        }
    }
}
