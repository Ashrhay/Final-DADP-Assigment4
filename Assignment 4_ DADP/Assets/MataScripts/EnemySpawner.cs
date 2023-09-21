using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject EnemyPrefab;

    public int minNumberOfEnemies = 1;
    public int maxNumberOfEnemies = 3;

    public float spawnRadius = 5f;
    public float spawnInterval = 7f;

    private int totalEnemiesSpawned = 0; // Track the total number of enemies spawned.

    private void Start()
    {
        InvokeRepeating("SpawnEnemies", 0f, spawnInterval);
    }

    private void SpawnEnemies()
    {
        int numberOfEnemiesToSpawn = Random.Range(minNumberOfEnemies, maxNumberOfEnemies + 1);

        for (int i = 0; i < numberOfEnemiesToSpawn && totalEnemiesSpawned < 20; i++)
        {
            Vector3 randomSpawnPos = Random.insideUnitSphere * spawnRadius;
            RaycastHit hit;

            if (Physics.Raycast(transform.position + randomSpawnPos, Vector3.down, out hit))
            {
                Vector3 spawnPosition = hit.point; // Use the point where the raycast hit the ground
                Instantiate(EnemyPrefab, spawnPosition, Quaternion.identity);
                totalEnemiesSpawned++; // Increment the total count.
            }
        }
    }
}
