using System;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    [SerializeField] private float shootSpeed;

    private Vector3 direction;
    private void Awake()
    {
        direction = Vector3.right;
    }

    private void Update()
    {
        transform.Translate(direction * shootSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("EnemyBullet"))
        {
            Destroy(gameObject);
            Destroy(col.gameObject);
        }
    }
}
