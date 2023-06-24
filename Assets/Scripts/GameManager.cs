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
        [SerializeField] private GameObject shootingEnemy;
        [SerializeField] private GameObject shooting3DEnemy;
        public GameObject voja;
        public GameObject barricade;
        public GameObject tiredness;

        public bool spawn;

        private void Start()
        {
            spawn = true;
            Instantiate(barricade);
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
            var enemyType = Random.Range(0, 10);
            if(enemyType < 5)
                Instantiate(enemy, waypoints[Random.Range(0,8)].transform.position, Quaternion.identity);
            else if(enemyType < 8)
                Instantiate(shootingEnemy, waypoints[Random.Range(0,8)].transform.position, Quaternion.identity);
            else 
                Instantiate(shooting3DEnemy, waypoints[Random.Range(0,8)].transform.position, Quaternion.identity);
            yield return new WaitForSeconds(2f);
            spawn = true;
        }
    }
