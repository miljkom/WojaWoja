using System;
using Unity.Mathematics;
using UnityEngine;

public class ShootBullet : MonoBehaviour
{
    [SerializeField] private GameObject bullet;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            Instantiate(bullet, transform.position, quaternion.identity);
    }
}
