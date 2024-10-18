using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform _enemySpawnPoint;
    public GameObject _enemyPrefab;

    private void Start()
    {
        StartCoroutine(SpawnEnemyEveryTwoSeconds());
    }

    private IEnumerator SpawnEnemyEveryTwoSeconds()
    {
        SpawnEnemy();
        yield return new WaitForSeconds(2f);
        while (GameManager.instance.GetIsAlive())
        {
            SpawnEnemy();
            yield return new WaitForSeconds(2f);
        }
    }

    private void SpawnEnemy()
    {
        Instantiate(_enemyPrefab, _enemySpawnPoint.position, Quaternion.identity);
    }
}
