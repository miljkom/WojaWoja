using System;
using System.Collections;
using Unity.Mathematics;
using UnityEngine;

public class EnemySpawnBullet : MonoBehaviour
{
    [SerializeField] private float spawnBulletsInSeconds;
    [SerializeField] private GameObject enemyBullet;
    private bool isBorko;
    private void Start()
    {
        if (gameObject.CompareTag("Borko"))
        {
            isBorko = true;
            StartCoroutine(SpawnEnemyBullets());
        }
        else
        {
            isBorko = false;
           StartCoroutine(SpawnEnemyBullets());
        }
    }

    private IEnumerator SpawnEnemyBullets()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnBulletsInSeconds);
            if (isBorko)
            {
                Instantiate(enemyBullet, gameObject.transform.GetChild(0).transform);
            }
            Instantiate(enemyBullet, transform.position + Vector3.left, quaternion.identity);
        }
    }
}
