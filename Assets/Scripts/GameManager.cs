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
    [SerializeField] private GameObject advanced4;
    [SerializeField] private GameObject friendly1;
    [SerializeField] private GameObject friendly2;
    [SerializeField] private GameObject friendly3;
    [SerializeField] private GameObject friendly4;
    [SerializeField] private GameObject friendly5;
    [SerializeField] private GameObject friendly6;
    [SerializeField] public GameObject voja;
    [SerializeField] private Image chargerImage;
    public float chargerDamage;
    public List<GameObject> barricade;
    public List<GameObject> realBarricade;
    public GameObject tiredness;
    public GameObject charger;
    
    private int waypointsCount;
    public bool DestroyBarricade { get; set; }

    private void Start()
    {
        Application.targetFrameRate = GameConstants.Instance.GameFps;
        waypointsCount = waypoints.Count;
        for (int i = 0; i < barricade.Count; i++)
        {
            realBarricade[i] = Instantiate(barricade[i]);
        }
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
        Instantiate(friendly1, waypoints[Random.Range(0, waypointsCount)].transform.position, Quaternion.identity);
    }
    public void SpawnFriendly2()
    {
        Instantiate(friendly2, waypoints[Random.Range(0, waypointsCount)].transform.position, Quaternion.identity);
    }
    public void SpawnFriendly3()
    {
        Instantiate(friendly3, waypoints[Random.Range(0, waypointsCount)].transform.position, Quaternion.identity);
    }
    public void SpawnFriendly4()
    {
        Instantiate(friendly4, waypoints[Random.Range(0, waypointsCount)].transform.position, Quaternion.identity);
    }
    public void SpawnFriendly5()
    {
        Instantiate(friendly5, waypoints[Random.Range(0, waypointsCount)].transform.position, Quaternion.identity);
    }
    public void SpawnFriendly6()
    {
        Instantiate(friendly6, waypoints[Random.Range(0, waypointsCount)].transform.position, Quaternion.identity);
    }
    public void SpawnAdvanced3()
    {
        Instantiate(advanced3, waypoints[Random.Range(0, waypointsCount)].transform.position, Quaternion.identity);
    }
    
    public void SpawnAdvanced4()
    {
        Instantiate(advanced4, waypoints[Random.Range(0, waypointsCount)].transform.position, Quaternion.identity);
    }
}