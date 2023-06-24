using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] private List<GameObject> waypoints;
    [SerializeField] private GameObject enemy;
    [FormerlySerializedAs("shootingEnemy")] [SerializeField] private GameObject advanced1;
    [FormerlySerializedAs("shooting3DEnemy")] [SerializeField] private GameObject advanced2;
    [SerializeField] private GameObject advanced3;
    [SerializeField] public GameObject voja;
    [SerializeField] private Image chargerImage;
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

            chargerImage.fillAmount = Player.Instance.charger;
        }
        
        private IEnumerator SpawnEnemies()
        {
            spawn = false;
            var enemyType = Random.Range(0, 10);
            if(enemyType < 5)
                Instantiate(enemy, waypoints[Random.Range(0,8)].transform.position, Quaternion.identity);
            else if(enemyType < 8)
                Instantiate(advanced1, waypoints[Random.Range(0,8)].transform.position, Quaternion.identity);
            else 
                Instantiate(advanced2, waypoints[Random.Range(0,8)].transform.position, Quaternion.identity);
            yield return new WaitForSeconds(2f);
            spawn = true;
        }

        public void SpawnNormal()
        {
            Instantiate(enemy, waypoints[Random.Range(0, 8)].transform.position, Quaternion.identity);
        }


        public void SpawnAdvanced1()
        {
            Instantiate(advanced1, waypoints[Random.Range(0, 8)].transform.position, Quaternion.identity);
        }
        
        
        public void SpawnAdvanced2()
        {
            Instantiate(advanced2, waypoints[Random.Range(0, 8)].transform.position, Quaternion.identity);
        }
        
        
        public void SpawnAdvanced3()
        {
            Instantiate(advanced3, waypoints[Random.Range(0, 8)].transform.position, Quaternion.identity);
        }
}