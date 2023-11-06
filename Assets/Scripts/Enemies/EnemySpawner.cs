using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] public Transform positionToSpwanAt;
    [SerializeField] private float spawnRate = 1.0f;
    [SerializeField] private bool canSpawn;
    [SerializeField] private GameObject[] enemyPrefabs;

    

    private void Start()
    {
        StartCoroutine(Spawner());
    }

    private IEnumerator Spawner()
    {
        WaitForSeconds waitTime = new WaitForSeconds(spawnRate);

        while (canSpawn)
        {
            yield return waitTime;

            int indexOfEnemyPrefabToSpawn = Random.Range(0, enemyPrefabs.Length);
            GameObject enemyPrefabToSpawn = enemyPrefabs[indexOfEnemyPrefabToSpawn];

            Instantiate(enemyPrefabToSpawn, positionToSpwanAt.position, Quaternion.identity);
        }

    }
}
