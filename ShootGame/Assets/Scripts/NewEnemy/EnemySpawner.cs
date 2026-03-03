using UnityEngine;
using UnityEngine.AI;

public class EnemySpawner : MonoBehaviour
{

    public GameObject enemyPrefab;

    public float spawnInterval = 5f;

    public int spawnCount = 3;

    private float timer;

    public float spawnRadius = 10f;

    public int maxEnemies = 10;

    public string tagName = "";

    public bool isPickup = false;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnEnemies();
            timer = 0f;
        }
    }

    void SpawnEnemies()
    {
        for(int i = 0;i<spawnCount;i++)
        {
            if(GameObject.FindGameObjectsWithTag(tagName).Length >= maxEnemies)
            {
                return;
            }
            Vector3 spawnPosition = GetRandomSpawnPosition();

            if(isPickup)
            {
                spawnPosition.y = 1.2f;
            }
            Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
        }
    }

    Vector3 GetRandomSpawnPosition()
    {
        Vector3 randomPosition = transform.position + Random.insideUnitSphere * spawnRadius;
        
        NavMeshHit hit;
        if(NavMesh.SamplePosition(randomPosition, out hit, spawnRadius, NavMesh.AllAreas))
        {
            return hit.position;
        }
        else
        {
            return transform.position;
        }
    }
}
