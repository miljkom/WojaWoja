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
    private SpriteRenderer chargerRenderer;
    private float chargerPercent;
    [SerializeField] private AudioSource stani;
    [SerializeField] private float freshenUp;
    [SerializeField] private float relaxCooler;
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
        //chargerRenderer = GameManager.Instance.charger.GetComponent<SpriteRenderer>();
        charger = 0;
    }

    private void Update()
    {
        if(tiredness > 0)
        {
            if (fresh)
            {
                tiredness -= Time.deltaTime * freshenUp;
            }
            else
            {
                tiredness -= Time.deltaTime * relaxCooler;
            }
            spriteRenderer.material.SetFloat("_Fill", tiredness);
        }
        if (tiredness >= 1)
        {
            if (!stani.isPlaying)
                stani.Play();
            fresh = false;
        }
        else if (tiredness <= 0)
        {
            fresh = true;
        }
    }

    public void FillCharger()
    {
        chargerRenderer.material.SetFloat("_Fill", charger);
        if (chargerPercent >= 100)
        {
            //filled
        }
    }
}
