using Unity.Mathematics;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;
using UnityEngine.Rendering.UI;

public class ShootBullet : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private Animator _animator;
    [SerializeField] private Transform spawnPointBullet;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Player.Instance.fresh)
        {
            Instantiate(bullet, spawnPointBullet.position, quaternion.identity);
            _animator.Play("Voja_Shoot");
            Player.Instance.tiredness += 0.1f;
        }
    }
}
