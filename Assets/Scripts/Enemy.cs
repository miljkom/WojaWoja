using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    public float health;

    private void Update()
    {
        if (health == 0)
        {
            Destroy(gameObject);
        }
        transform.position = Vector3.MoveTowards(transform.position, GameManager.Instance.voja.transform.position, speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Bullet"))
        {
            health -= 25f;
            Destroy(col.gameObject);
        }
    }
}
