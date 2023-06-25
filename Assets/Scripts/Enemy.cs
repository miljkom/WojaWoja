using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    public float health;

    private float startingSpeed;
    private bool _isDead = false;
    public bool _canPass = false;

    private bool shooterDisabled;
    
    private void Awake()
    {
        startingSpeed = speed;
    }
    
    private void Update()
    {
        if (gameObject.CompareTag("LastBlocker") && health <= 0)
        {
            GameManager.Instance.GameOver();
        }
        if (health <= 0 && !_isDead)
        {
            Player.Instance.charger += 0.08f;
            KillEnemy();
            _isDead = true;
        }
        //transform.position = Vector3.MoveTowards(transform.position, GameManager.Instance.voja.transform.position, speed * Time.deltaTime); 
        transform.Translate(Vector3.left * speed * Time.deltaTime);
        if (transform.position.x < -2 && !shooterDisabled)
        {
            if (GetComponent<EnemySpawnBullet>() != null)
                GetComponent<EnemySpawnBullet>().isDisabled = true;
            shooterDisabled = true;
        }
            
        if (GameManager.Instance.realBarricade.Any(x => x.IsDestroyed()) && !_isDead)
        {
            if (_canPass)
            {
                speed = startingSpeed;
                GetComponentInChildren<Animator>().SetBool("IsWalking", true);
            }

        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Bullet"))
        {
            health -= 25f;
            GetComponentInChildren<Animator>().Play("BasicEnemy_Flich");
            StartCoroutine(GetComponentInChildren<WhiteHit>().PlayWhiteHit(.2f));
            Destroy(col.gameObject);
        }

        if (col.gameObject.CompareTag("Charger"))
        {
            health -= GameManager.Instance.chargerDamage;
            GetComponentInChildren<Animator>().Play("BasicEnemy_Flich");
            StartCoroutine(GetComponentInChildren<WhiteHit>().PlayWhiteHit(.2f));
        }
        if (col.CompareTag("Blocker"))
        {
            _canPass = false;
            speed = 0;
            GetComponentInChildren<Animator>().SetBool("IsWalking", false);
        }
        if (col.CompareTag("LastBlocker"))
        {
            _canPass = false;
            speed = 0;
            GetComponentInChildren<Animator>().SetBool("IsWalking", false);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Blocker"))
        {
            _canPass = true;
        }
    }

    public void KillEnemy()
    {
        speed = 0;
        GameManager.Instance.killCount++;
        GetComponentInChildren<Animator>().Play("BasicEnemy_Death");
        GetComponent<BoxCollider2D>().enabled = false;
    }
}