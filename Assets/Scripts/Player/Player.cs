using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Player : Singleton<Player>
{
    public float health;
    public float tiredness;
    public bool fresh = true;
    public float charger;
    public bool chargerReadyFlag;
    private SpriteRenderer spriteRenderer;
    private SpriteRenderer spriteRendererGlow;
    private SpriteRenderer chargerRenderer;
    private float chargerPercent;
    [SerializeField] private AudioSource stani;
    [SerializeField] private AudioSource chargerReady;
    [SerializeField] private float freshenUp;
    [SerializeField] private float relaxCooler;
    [SerializeField] private List<GameObject> fullHearts;

    private int healthCounter;
    private Animator _animator;
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("EnemyBullet"))
        {

            health--;
            healthCounter--;
            fullHearts[healthCounter].SetActive(false);
            Destroy(col.gameObject);
            if (health <= 0)
            {
                GameManager.Instance.GameOver();
                Destroy(gameObject);
                Debug.LogError("Game over");
            }
        }
    }

    private void Start()
    {
        spriteRenderer = GameManager.Instance.tiredness.GetComponent<SpriteRenderer>();
        //chargerRenderer = GameManager.Instance.charger.GetComponent<SpriteRenderer>();
        charger = 0;
        _animator = GetComponentInChildren<Animator>();
        healthCounter = fullHearts.Count;
        chargerReadyFlag = true;
    }

    private void Update()
    {
        if (charger >= 1 && chargerReadyFlag)
        {
            if (!chargerReady.isPlaying)
            {
                chargerReady.Play();
                chargerReadyFlag = false;
            }
        }
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
            _animator.SetBool("isHeated",true);
            _animator.Play("Voja_IndikatorScaleOverheat");
        }
        else if (tiredness <= 0)
        {
            _animator.SetBool("isHeated",false);
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

    public void AddLife()
    {
        if (healthCounter < 5)
        {
            fullHearts[healthCounter].SetActive(true);
            healthCounter++;
        }
    }

    public void RemoveLife()
    {
        if (healthCounter < 1)
        {
            //gameover
            Destroy(gameObject);
            return;
        }
        healthCounter--;
        fullHearts[healthCounter].SetActive(false);
    }
}
