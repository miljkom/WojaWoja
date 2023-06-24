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
    private bool isBorko;

    private void Update()
    {
        if (health <= 0)
        {
            GameManager.Instance.DestroyBarricade = true;
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
                health -= 5f;
            }
            else
            {
                health -= 1f;
            }
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
