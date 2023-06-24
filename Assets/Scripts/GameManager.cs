using System.Collections.Generic;
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

    private int waypointsCount;

    private void Start()
    {
        waypointsCount = waypoints.Count;
        Instantiate(barricade);
    }

    private void Update()
    {
        chargerImage.fillAmount = Player.Instance.charger;
    }
    

    public void SpawnNormal()
    {
        Instantiate(enemy, waypoints[Random.Range(0, waypointsCount)].transform.position, Quaternion.identity);
    }


    public void SpawnAdvanced1()
    {
        Instantiate(advanced1, waypoints[Random.Range(0, waypointsCount)].transform.position, Quaternion.identity);
    }


    public void SpawnAdvanced2()
    {
        Instantiate(advanced2, waypoints[Random.Range(0, waypointsCount)].transform.position, Quaternion.identity);
    }


    public void SpawnAdvanced3()
    {
        Instantiate(advanced3, waypoints[Random.Range(0, waypointsCount)].transform.position, Quaternion.identity);
    }
}