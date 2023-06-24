using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] private List<GameObject> waypoints;
    [SerializeField] private GameObject enemy;
    [SerializeField] private GameObject advanced1;
    [SerializeField] private GameObject advanced2;
    [SerializeField] private GameObject advanced3;
    [SerializeField] private GameObject friendly1;
    [SerializeField] private GameObject friendly2;
    [SerializeField] public GameObject voja;
    [SerializeField] private Image chargerImage;
    public GameObject barricade;
    public GameObject realBarricade;
    public GameObject tiredness;
    public GameObject borkoPointer;

    private int waypointsCount;
    public bool DestroyBarricade { get; set; }

    private void Start()
    {
        Application.targetFrameRate = GameConstants.Instance.GameFps;
        waypointsCount = waypoints.Count;
        realBarricade = Instantiate(barricade);
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
    public void SpawnFriendly1()
    {
        borkoPointer = Instantiate(friendly1, waypoints[Random.Range(0, waypointsCount)].transform.position, Quaternion.identity);
    }


    public void SpawnAdvanced3()
    {
        Instantiate(advanced3, waypoints[Random.Range(0, waypointsCount)].transform.position, Quaternion.identity);
    }
}