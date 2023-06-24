using Unity.Mathematics;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;
using UnityEngine.Rendering.UI;

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
            _animator.Play("Voja_IndikatorScale");
            Player.Instance.tiredness += 0.1f;
        }
    }
}
