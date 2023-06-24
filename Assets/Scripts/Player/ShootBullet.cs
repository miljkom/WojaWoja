using System;
using Unity.Mathematics;
using UnityEngine;

public class ShootBullet : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private GameObject bulletUp;
    [SerializeField] private GameObject bulletDown;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            Instantiate(bullet, transform.position + Vector3.right, quaternion.identity);

        if (Input.GetKeyDown(KeyCode.F))
        {
            var playerPosition = transform.position + Vector3.right;
            Instantiate(bullet, playerPosition, quaternion.identity);
            Instantiate(bulletUp, playerPosition, quaternion.identity);
            Instantiate(bulletDown, playerPosition, quaternion.identity);
        }
    }
}
