using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    private float spawnInterval = 4.0f; // Khoảng thời gian giữa các lần sinh kẻ thù

    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnInterval);
            SpawnEnemy();
        }
    }

    private void SpawnEnemy()
    {
        Debug.Log("Attempting to spawn an enemy...");
        if (enemyPrefab != null)
        {
            Vector3 spawnPosition = new Vector3(Random.Range(-7.0f, 7.0f), 10.0f, 0.0f); // Điều chỉnh vị trí x trong khoảng từ -7 đến 7
            GameObject spawnedEnemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
            if (spawnedEnemy != null)
            {
                spawnedEnemy.tag = "Enemy"; // Gán tag "Enemy" cho đối tượng kẻ thù
                Debug.Log("Spawned an enemy at: " + spawnPosition);
            }
            else
            {
                Debug.LogError("Failed to spawn enemy at: " + spawnPosition);
            }
        }
        else
        {
            Debug.LogError("enemyPrefab is not assigned in the Inspector.");
        }
    }
}


