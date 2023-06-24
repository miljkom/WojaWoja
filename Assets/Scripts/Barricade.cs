using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;

public class Barricade : MonoBehaviour
{
    [SerializeField] private float health;

    private bool inside;
    private void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Enemy"))
        {
            inside = true;
            StartCoroutine(LoseHealth());
            health -= 1f;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            inside = false;
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
            health -= 1f;
            Debug.Log(health);
            yield return new WaitForSeconds(1f);
        }
        if (!inside)
        {
            yield break;
        }
        StartCoroutine(LoseHealth());
    }
}
