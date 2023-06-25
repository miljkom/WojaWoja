using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;

public class Barricade : MonoBehaviour
{
    [SerializeField] private float health;
    [SerializeField] private float borkoDamage = 2f;
    [SerializeField] private float enemyDamage = 1f;
    [SerializeField] private float urosDamage = 3f;

    private bool inside;
    private bool isBorko;
    private bool isUros;

    private SpriteRenderer sprite;

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        if (health <= 0)
        {
            if (gameObject.CompareTag("LastBlocker"))
                GameManager.Instance.GameOver();
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Enemy"))
        {
            inside = true;
            StartCoroutine(LoseHealth());
        }

        if (col.CompareTag("Borko"))
        {
            inside = true;
            isBorko = true;
            StartCoroutine(LoseHealth());
        }

        if (col.CompareTag("Uros"))
        {
            inside = true;
            isUros = true;
            StartCoroutine(LoseHealth());
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            inside = false;
        }

        if (other.CompareTag("Borko"))
        {
            inside = false;
            isBorko = false;
        }
        
        if (other.CompareTag("Uros"))
        {
            inside = false;
            isUros = false;
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            inside = true;
        }
    }

    private IEnumerator LoseHealth()
    {
        while (inside)
        {
            if (isBorko)
            {
                health -= borkoDamage;
            }

            if (isUros)
            {
                health -= urosDamage;
            }
            else
            {
                health -= enemyDamage;
            }
            StartCoroutine(PlayRedHit(.1f));
            Debug.Log(health);
            yield return new WaitForSeconds(1f);
        }
        if (!inside)
        {
            yield break;
        }
        StartCoroutine(LoseHealth());
    }
    public IEnumerator PlayRedHit(float duration)
    {
        float intensity = 0f;
        var elapsedTime = 0f;
        while(elapsedTime < duration)
        {
            float currentValue = Mathf.Lerp(intensity, .5f, elapsedTime / duration);
            sprite.material.SetFloat("_Intensity", currentValue);
            elapsedTime += Time.deltaTime;
            yield return null;  
        }
        elapsedTime = 0f;
        while(elapsedTime < duration)
        {
            float currentValue = Mathf.Lerp(intensity, 0, elapsedTime / duration);
            sprite.material.SetFloat("_Intensity", currentValue);
            elapsedTime += Time.deltaTime;
            yield return null;  
        }
    }
}
