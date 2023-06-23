using System;
using System.Collections;
using Unity.Mathematics;
using UnityEngine;

public class EnemySpawnBullet : MonoBehaviour
{
    [SerializeField] private float spawnBulletsInSeconds;
    [SerializeField] private GameObject enemyBullet;
    
    private void Start()
    {
        StartCoroutine(SpawnEnemyBullets());
    }

    private IEnumerator SpawnEnemyBullets()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnBulletsInSeconds);
            Instantiate(enemyBullet, transform.position + Vector3.left, quaternion.identity);
        }
    }
}
