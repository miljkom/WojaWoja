using System;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class ShootBullet : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private GameObject gigaBullet;
    [SerializeField] private GameObject molimBullet;
    [SerializeField] private GameObject koSitiBullet;
    [SerializeField] private AudioSource otkaz;
    [SerializeField] private AudioSource gigaOtkaz;
    [SerializeField] private AudioSource molim;
    [SerializeField] private AudioSource kosiTi;
    [SerializeField] private Animator _animator;
    [SerializeField] private Transform spawnPointBullet;
    [SerializeField] private Transform gigaSpawnPointBullet;
    [SerializeField] private float fillCooldowner;
    private List<GameObject> maybeRandom = new List<GameObject>();
    private List<AudioSource> audioRandom = new List<AudioSource>();

    private void Awake()
    {
        maybeRandom.Add(bullet);
        audioRandom.Add(otkaz);
        maybeRandom.Add(molimBullet);
        audioRandom.Add(molim);
        maybeRandom.Add(koSitiBullet);
        audioRandom.Add(kosiTi);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Player.Instance.fresh)
        {
            int randomIndex = Random.Range(0, maybeRandom.Count);
            Instantiate(maybeRandom[randomIndex], spawnPointBullet.position, quaternion.identity);
            _animator.Play("Voja_Shoot");
            if (!molim.isPlaying && !otkaz.isPlaying && !kosiTi.isPlaying)
            {
                audioRandom[randomIndex].Play();
            }
            _animator.Play("Voja_IndikatorScale");
            Player.Instance.tiredness += fillCooldowner;
        }
        if(Input.GetKeyDown(KeyCode.F) && Player.Instance.charger >= 1f)
        {
            Instantiate(gigaBullet, gigaSpawnPointBullet.position, Quaternion.identity);
            _animator.Play("Voja_Shoot");
            if (!gigaOtkaz.isPlaying)
            {
                gigaOtkaz.Play();
            }
            Player.Instance.charger = 0;
        }
    }
}
