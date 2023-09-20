using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject EnemyPrefab;

    public int minNumberOfEnemies = 1;
    public int maxNumberOfEnemies = 3;

    public float spawnRadius = 5f;
    public float spawnInterval = 7f;

    public Transform spawner; // Assign the 'Spawner' GameObject in the Unity Inspector

    public float minDistanceBetweenEnemies = 2f; // Minimum distance between spawned enemies

    private void Start()
    {
        InvokeRepeating("SpawnEnemies", 0f, spawnInterval);
    }

    private void SpawnEnemies()
    {
        int numberOfEnemiesToSpawn = Random.Range(minNumberOfEnemies, maxNumberOfEnemies + 1);

        for (int i = 0; i < numberOfEnemiesToSpawn; i++)
        {
            Vector3 randomSpawnPos = Random.insideUnitSphere * spawnRadius;
            RaycastHit hit;

            if (Physics.Raycast(spawner.position + randomSpawnPos, Vector3.down, out hit))
            {
                Vector3 spawnPosition = hit.point; // Use the point where the raycast hit the ground

                // Check if there's already an enemy within the minimum distance
                Collider[] colliders = Physics.OverlapSphere(spawnPosition, minDistanceBetweenEnemies);
                bool isOverlapping = false;

                foreach (var collider in colliders)
                {
                    if (collider.CompareTag("Enemy"))
                    {
                        isOverlapping = true;
                        break;
                    }
                }

                if (!isOverlapping)
                {
                    Instantiate(EnemyPrefab, spawnPosition, Quaternion.identity);
                }
            }
        }
    }
}
