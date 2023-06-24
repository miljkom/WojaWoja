using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using static GameManager;

public class EnemyBulletMovement : MonoBehaviour
{
    
    [SerializeField] private float shootSpeed;
    
    private Vector3 targetTransform;
    private Vector2 direction;

    private void Start()
    {
        direction = (GameManager.Instance.voja.transform.position - transform.position).normalized;
    }

    private void Update()
    {
        transform.Translate(direction * shootSpeed * Time.deltaTime);
    }
    
}
