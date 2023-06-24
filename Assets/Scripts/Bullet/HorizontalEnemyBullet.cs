using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalEnemyBullet : MonoBehaviour
{
    [SerializeField] private float shootSpeed;

    private Vector3 direction;
    private void Awake()
    {
        direction = Vector3.left;
    }

    private void Update()
    {
        transform.Translate(direction * shootSpeed * Time.deltaTime);
    }
}
