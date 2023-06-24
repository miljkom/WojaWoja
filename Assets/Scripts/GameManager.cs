using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
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
    public GameObject barricade;
    public GameObject tiredness;
    
    private void Start()
    {
        Instantiate(barricade);
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