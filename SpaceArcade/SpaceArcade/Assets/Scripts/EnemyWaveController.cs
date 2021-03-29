using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWaveController : MonoBehaviour
{
    public GameObject enemyPrefab1;
    public GameObject enemyPrefab2;
    public GameObject enemyPrefab3;
    public Transform firePoint;
    public bool stupidWave = false;
    void Update(){
        GameObject[] allEnemies = GameObject.FindGameObjectsWithTag("Enemy");
        if (allEnemies.Length == 0){
            if (!stupidWave)
            {
                Instantiate(enemyPrefab1, new Vector3(14, 3, 0), new Quaternion(0f, 0f, 1f, 1f));
              //  Instantiate(enemyPrefab3, firePoint.position, firePoint.rotation);
                Instantiate(enemyPrefab1, new Vector3(14, 0, 0), new Quaternion(0f, 0f, 1f, 1f));
            //    Instantiate(enemyPrefab3, new Vector3(14, 0, 0), new Quaternion(0f, 0f, 1f, 1f));
                Instantiate(enemyPrefab1, new Vector3(14, -3, 0), new Quaternion(0f, 0f, 1f, 1f));
          //      Instantiate(enemyPrefab3, new Vector3(14, -3, 0), new Quaternion(0f, 0f, 1f, 1f));
                stupidWave = true;
            }else{
                Instantiate(enemyPrefab2, new Vector3(14, 0, 0), new Quaternion(0f, 0f, 1f, 1f));
                stupidWave = false;
            }
        }
    }
}
