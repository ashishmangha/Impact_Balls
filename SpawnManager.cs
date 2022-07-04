using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private float spawnRange = 9;
    public GameObject enemyPrefab;
    public GameObject powerupPrefab;
    public int enemyCount;
    public int waveNumber = 1;
    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemyWave(waveNumber);
        Instantiate(powerupPrefab, GenarateSpawnPosition(), enemyPrefab.transform.rotation);
    }

    void SpawnEnemyWave(int enemytoSpawn)
    {
        for (int i = 0; i < enemytoSpawn; i++)
        {
            Instantiate(enemyPrefab, GenarateSpawnPosition(), enemyPrefab.transform.rotation);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length;
        if(enemyCount == 0)
        {
            waveNumber++;
            SpawnEnemyWave(waveNumber);
            Instantiate(powerupPrefab, GenarateSpawnPosition(), enemyPrefab.transform.rotation);
        }
        
    }

    private Vector3 GenarateSpawnPosition()
    {
        float randomX = Random.Range(-spawnRange, spawnRange);
        float randomZ = Random.Range(-spawnRange, spawnRange);
        Vector3 randomPos = new Vector3(randomX, 0, randomZ);
        return randomPos;
    }
}
