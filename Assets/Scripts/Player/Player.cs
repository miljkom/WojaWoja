using System;
using System.Collections;
using UnityEngine;

public class Player : Singleton<Player>
{
    public float health;
    public float tiredness;
    public bool fresh = true;
    public float charger;
    private SpriteRenderer spriteRenderer;
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("EnemyBullet") || col.CompareTag("Enemy"))
        {
            if (health <= 0)
            {
                Destroy(gameObject);
            }
            health--;
            Destroy(col.gameObject);
            Debug.LogError("Game over");
        }
    }

    private void Start()
    {
        spriteRenderer = GameManager.Instance.tiredness.GetComponent<SpriteRenderer>();
        charger = 0;
    }

    private void Update()
    {
        if(tiredness > 0)
        {
            if (fresh)
            {
                tiredness -= Time.deltaTime * 0.1f;
            }
            else
            {
                tiredness -= Time.deltaTime * 0.25f;
            }
            spriteRenderer.material.SetFloat("_Fill", tiredness);
        }
        if (tiredness >= 1)
        {
            fresh = false;
        }
        else if (tiredness <= 0)
        {
            fresh = true;
        }
    }
}
