using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    public float health;

    private float startingSpeed;
    
    private void Awake()
    {
        startingSpeed = speed;
    }

    private void Update()
    {
        if (health <= 0)
        {
            Player.Instance.charger += 0.1f;
            Destroy(gameObject);
        }
        //transform.position = Vector3.MoveTowards(transform.position, GameManager.Instance.voja.transform.position, speed * Time.deltaTime); 
        transform.Translate(Vector3.left * speed * Time.deltaTime);
        if (GameManager.Instance.DestroyBarricade)
        {
            speed = startingSpeed;
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Bullet"))
        {
            health -= 25f;
            Destroy(col.gameObject);
        }

        if (col.gameObject.CompareTag("Charger"))
        {
            health -= 50f;
        }
        if (col.CompareTag("Blocker"))
        {
            speed = 0;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Blocker"))
        {
            speed = 2f;
        }
    }
}
