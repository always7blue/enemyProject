using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;  // Spawn edilecek düþman prefab'ý
    public int maxEnemies = 20;     // Ayný anda bulunacak maksimum düþman sayýsý
    public float spawnInterval = 4f; // 4 saniyede bir spawn

    private int currentEnemyCount = 0; // Mevcut düþman sayýsý

    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies()
    {
        while (true)
        {
            if (currentEnemyCount < maxEnemies)
            {
                Vector3 spawnPosition = GetRandomNavMeshPosition();
                if (spawnPosition != Vector3.zero)
                {
                    Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
                    currentEnemyCount++;
                }
            }
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    Vector3 GetRandomNavMeshPosition()
    {
        Vector3 randomPosition = transform.position + Random.insideUnitSphere * 20f; // 20 birimlik bir alan
        NavMeshHit hit;
        if (NavMesh.SamplePosition(randomPosition, out hit, 20f, NavMesh.AllAreas))
        {
            return hit.position;
        }
        return Vector3.zero; // Geçerli bir NavMesh pozisyonu bulunamazsa
    }

    public void OnEnemyDestroyed()
    {
        currentEnemyCount--; // Bir düþman yok edildiðinde sayýyý azalt
    }
}
