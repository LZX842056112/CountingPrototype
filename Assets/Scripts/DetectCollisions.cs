using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollisions : MonoBehaviour
{
    private GameManager gameManager;
    public GameObject Sword;
    private float spawnRangex = 30;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Spawn Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        if (other.CompareTag("Enemy"))
        {
            Transform parent = other.transform.parent;
            Destroy(other.gameObject);
            if (parent != null)
            {
                Destroy(parent.gameObject);
            }
            gameManager.UpdateCount(1);
        }else if (other.CompareTag("Powerup"))
        {
            Destroy(other.gameObject);
            for (int i = 0;i <100; i++)
            {
                Instantiate(Sword, GenerateSpawnPosition(), Sword.transform.rotation);
            }

        }
    }

    public Vector3 GenerateSpawnPosition()
    {
        float spawnPosX = Random.Range(-spawnRangex, spawnRangex);
        float spawnPosZ = Random.Range(5, 50);
        Vector3 randomPos = new Vector3(spawnPosX, 20, spawnPosZ);
        return randomPos;
    }
}
