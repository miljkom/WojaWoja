using System;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    [SerializeField] private float shootSpeed;
    [SerializeField] private bool isEnemyBullet;

    private Vector3 direction;
    private void Awake()
    {
        direction = isEnemyBullet ? Vector3.left : Vector3.right;
    }

    private void Update()
    {
        transform.Translate(direction * shootSpeed * Time.deltaTime);
    }
}
