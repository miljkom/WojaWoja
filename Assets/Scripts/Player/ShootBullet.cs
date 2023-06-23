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
            Instantiate(bullet, transform.position, quaternion.identity);

        if (Input.GetKeyDown(KeyCode.F))
        {
            Instantiate(bullet, transform.position, quaternion.identity);
            Instantiate(bulletUp, transform.position, quaternion.identity);
            Instantiate(bulletDown, transform.position, quaternion.identity);
        }
    }
}
