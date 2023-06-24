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
    private bool _isDead = false;
    
    private void Awake()
    {
        startingSpeed = speed;
    }

    private void Update()
    {
        if (health <= 0 && !_isDead)
        {
            Player.Instance.charger += 0.1f;
            _isDead = true;
            KillEnemy();
        }
        //transform.position = Vector3.MoveTowards(transform.position, GameManager.Instance.voja.transform.position, speed * Time.deltaTime); 
        transform.Translate(Vector3.left * speed * Time.deltaTime);
        if (GameManager.Instance.realBarricade.IsDestroyed())
        {
            speed = 2f;
            GetComponentInChildren<Animator>().SetBool("IsWalking", true);
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Bullet"))
        {
            health -= 25f;
            GetComponentInChildren<Animator>().Play("BasicEnemy_Flich");
            Destroy(col.gameObject);
        }

        if (col.gameObject.CompareTag("Charger"))
        {
            health -= 50f;
        }
        if (col.CompareTag("Blocker"))
        {
            speed = 0;
            GetComponentInChildren<Animator>().SetBool("IsWalking", false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Blocker"))
        {
            speed = 2f;
        }
    }

    public void KillEnemy()
    {
        speed = 0;
        GetComponentInChildren<Animator>().Play("BasicEnemy_Death");
        GetComponent<BoxCollider2D>().enabled = false;
    }
}