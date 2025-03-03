using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;


public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemyPrefab;

    private float spawnRangeX = 30;
    private float spawnPosZ = 50;
    private float startDelay = 2;
    private float spawnInterval = 1f;

    private GameManager gameManager;


    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomAnimal", startDelay, spawnInterval);
        gameManager = GameObject.Find("Spawn Manager").GetComponent<GameManager>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void SpawnRandomAnimal()
    {
        if (gameManager.isGameActive)
        {
            int animalIndex = Random.Range(0, enemyPrefab.Length);
            Vector3 spawnpos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0.5f, spawnPosZ);
            Instantiate(enemyPrefab[animalIndex], spawnpos, enemyPrefab[animalIndex].transform.rotation);
        }
    }
}
