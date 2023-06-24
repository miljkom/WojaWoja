using System;
using System.Collections;
using UnityEngine;

public class Player : Singleton<Player>
{
    public float health;
    public float tiredness;
    private SpriteRenderer spriteRenderer;
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("EnemyBullet") || col.CompareTag("Enemy"))
        {
            Destroy(gameObject);
            Destroy(col.gameObject);
            Debug.LogError("Game over");
        }
    }

    private void Start()
    {
        spriteRenderer = GameManager.Instance.tiredness.GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if(tiredness > 0)
        {
            tiredness -= Time.deltaTime * 0.05f;
            spriteRenderer.material.SetFloat("_Fill", tiredness);
        }
    }
}
