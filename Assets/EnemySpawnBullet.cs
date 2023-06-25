using System;
using System.Collections;
using Unity.Mathematics;
using UnityEngine;

public class EnemySpawnBullet : MonoBehaviour
{
    [SerializeField] private float spawnBulletsInSeconds;
    [SerializeField] private GameObject enemyBullet;
    [SerializeField] private Transform spawnPointBorko;
    private bool isBorko;
    public int borkoLimit;
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
        int bullets = 0;
        while (true)
        {
            yield return new WaitForSeconds(spawnBulletsInSeconds);
            switch (isBorko)
            {
                case true when borkoLimit > bullets:
                    bullets++;
                    Instantiate(enemyBullet, spawnPointBorko.position, Quaternion.identity);
                    break;
                case false:
                    Instantiate(enemyBullet, spawnPointBorko.transform.position + Vector3.left, Quaternion.identity);
                    break;
            }
        }
    }
}
