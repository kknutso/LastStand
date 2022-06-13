using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] float minSpawnDelay = 1f;
    [SerializeField] float maxSpawnDelay = 5f;
    [SerializeField] Enemy[] enemyPrefabs;
    
    bool spawn = true;

    IEnumerator Start()
    {
        while(spawn)
        {
            yield return new WaitForSeconds(Random.Range(minSpawnDelay, maxSpawnDelay));
            SpawnEnemy();
        }
    }

    public void StopSpawning()
    {
        spawn = false;
    }

    void SpawnEnemy()
    {
        var enemyIndex = Random.Range(0, enemyPrefabs.Length);
        Spawn(enemyPrefabs[enemyIndex]);
    }

    void Spawn(Enemy myEnemy)
    {
        Enemy newEnemy = Instantiate
            (myEnemy, transform.position, Quaternion.identity)
            as Enemy;
        newEnemy.transform.parent = transform;
    }
}
