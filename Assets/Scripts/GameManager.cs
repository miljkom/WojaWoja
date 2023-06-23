using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameManager: Singleton<GameManager>
    {

        [SerializeField] private List<GameObject> waypoints;
        [SerializeField] private GameObject enemy;
        [SerializeField] public GameObject voja;

        public bool spawn;

        private void Start()
        {
            spawn = true;
        }

        private void Update()
        {
            if (spawn)
            {
                StartCoroutine(SpawnEnemies());
            }
        }
        
        private IEnumerator SpawnEnemies()
        {
            spawn = false;
            var go =  Instantiate(enemy, waypoints[Random.Range(0,8)].transform.position, Quaternion.identity);
            yield return new WaitForSeconds(2f);
            spawn = true;
        }
    }
