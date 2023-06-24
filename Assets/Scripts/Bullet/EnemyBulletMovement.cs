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

    private void Awake()
    {
        targetTransform = GameManager.Instance.voja.transform.position;
    }

    private void Update()
    { 
        transform.Translate(Vector3.left * Time.deltaTime * shootSpeed);
        /*if (transform.position == targetTransform)
        {
            transform.position = Vector3.MoveTowards( transform.position, targetTransform, shootSpeed * Time.deltaTime);
        }*/
    }
    
}
