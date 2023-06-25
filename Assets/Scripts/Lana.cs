using System;
using UnityEngine;

public class Lana : MonoBehaviour
{
    [SerializeField] private float movementSpeed;
    [SerializeField] private float health;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Bullet"))
        {
            health -= 25f;
            //GetComponentInChildren<Animator>().Play("BasicEnemy_Flich");
            //StartCoroutine(GetComponentInChildren<WhiteHit>().PlayWhiteHit(.2f));
            Destroy(col.gameObject);

            if (health <= 0)
            {
                Destroy(gameObject);
                //game over splash screen
            }
        }
    }

    private void Update()
    {
        transform.Translate(Vector3.left * movementSpeed * Time.deltaTime);
    }
}
