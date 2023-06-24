using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiagonalBulletSpawner : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private GameObject bulletUp;
    [SerializeField] private GameObject bulletDown;
    [SerializeField] private float spawnBulletsInSeconds;

    private void Start()
    {
        StartCoroutine(SpawnEnemyBullets());
    }

    private IEnumerator SpawnEnemyBullets()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnBulletsInSeconds);
            var playerPosition = transform.position + Vector3.left;
            Instantiate(bullet, playerPosition, Quaternion.identity);
            Instantiate(bulletUp, playerPosition, Quaternion.identity);
            Instantiate(bulletDown, playerPosition, Quaternion.identity);
        }
    }
}
