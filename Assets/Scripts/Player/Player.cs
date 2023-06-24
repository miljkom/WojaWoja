using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("EnemyBullet") || col.CompareTag("Enemy"))
        {
            Destroy(gameObject);
            Destroy(col.gameObject);
            Debug.LogError("Game over");
        }
    }
}
