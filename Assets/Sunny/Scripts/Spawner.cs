using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Spawner : MonoBehaviour {

	public GameObject enemyPrefab;
	public GameObject enemyPrefab1;
	public GameObject enemyPrefab2;
	public GameObject enemyPrefab3;
	public GameObject enemyPrefab4;

    //Constantly generating enemies
    void Start()
    {
       
      
            InvokeRepeating("SpawnEnemy", 0, 2);

       
      
    }
    //Generating preforms
    void SpawnEnemy()
    {
       

    }


 
   
}
