using Unity.Mathematics;
using UnityEngine;

public class ShootBullet : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private Animator _animator;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(bullet, transform.position + Vector3.right, quaternion.identity);
            _animator.Play("Voja_Shoot");
        }
    }
}
