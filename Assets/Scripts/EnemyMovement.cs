using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed;
    public float health;

    public EnemyMovement(float speed, float health)
    {
        this.speed = speed;
        this.health = health;
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, GameManager.Instance.voja.transform.position, speed * Time.deltaTime);
    }
}
