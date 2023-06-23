using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private Transform endpoint;
    private float speed;
    private float health;

    public EnemyMovement(Transform endpoint, float speed, float health)
    {
        this.endpoint = endpoint;
        this.speed = speed;
        this.health = health;
    }
}
