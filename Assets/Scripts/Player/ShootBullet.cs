using System.Collections.Generic;
using Unity.Mathematics;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;
using UnityEngine.Rendering.UI;

public class ShootBullet : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private GameObject gigaBullet;
    [SerializeField] private AudioSource otkaz;
    [SerializeField] private Animator _animator;
    [SerializeField] private Transform spawnPointBullet;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Player.Instance.fresh)
        {
            Instantiate(bullet, spawnPointBullet.position, quaternion.identity);
            _animator.Play("Voja_Shoot");
            if (!otkaz.isPlaying)
            {
                otkaz.Play();
            }
            _animator.Play("Voja_IndikatorScale");
            Player.Instance.tiredness += 0.1f;
        }
        if(Input.GetKeyDown(KeyCode.F) && Player.Instance.charger >= 1f)
        {
            Instantiate(gigaBullet, spawnPointBullet.position, Quaternion.identity);
            _animator.Play("Voja_Shoot");
            Player.Instance.charger = 0;
        }
    }
}
