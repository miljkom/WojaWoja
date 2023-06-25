using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private List<float> advanced2Spawner;
    [FormerlySerializedAs("advancedSpawner")] [SerializeField] private List<float> advanced1Spawner;
    [FormerlySerializedAs("advanced2Spawner")] [SerializeField] private List<float> basicEnemies;
    [SerializeField] private List<float> advanced3Spawner;
    [SerializeField] private List<float> advanced4Spawner;
    [SerializeField] private List<float> friendly1Spawner;
    [SerializeField] private List<float> friendly2Spawner;
    [SerializeField] private List<float> friendly3Spawner;
    [SerializeField] private List<float> friendly4Spawner;
    [SerializeField] private List<float> friendly5Spawner;
    [SerializeField] private List<float> friendly6Spawner;
    [SerializeField] private AudioSource borko;

    private void Update()
    {
        var time = Time.timeSinceLevelLoad;
        if (advanced1Spawner.Count > 0)
        {
            if (time > advanced1Spawner[0])
            {
                advanced1Spawner.RemoveAt(0);
                GameManager.Instance.SpawnAdvanced1();
            }
        }

        if (basicEnemies.Count > 0)
        {
            if (time > basicEnemies[0])
            {
                basicEnemies.RemoveAt(0);
                GameManager.Instance.SpawnNormal();
            }
        }

        if (friendly1Spawner.Count > 0)
        {
            if (time > friendly1Spawner[0])
            {
                friendly1Spawner.RemoveAt(0);
                if(!borko.isPlaying)
                    borko.Play();
                GameManager.Instance.SpawnFriendly1();
            }
        }
        if (friendly2Spawner.Count > 0)
        {
            if (time > friendly2Spawner[0])
            {
                friendly2Spawner.RemoveAt(0);
                GameManager.Instance.SpawnFriendly2();
            }
        }
        if (friendly3Spawner.Count > 0)
        {
            if (time > friendly3Spawner[0])
            {
                friendly3Spawner.RemoveAt(0);
                GameManager.Instance.SpawnFriendly3();
            }
        }
        if (friendly4Spawner.Count > 0)
        {
            if (time > friendly4Spawner[0])
            {
                friendly4Spawner.RemoveAt(0);
                GameManager.Instance.SpawnFriendly4();
            }
        }
        if (friendly5Spawner.Count > 0)
        {
            if (time > friendly5Spawner[0])
            {
                friendly5Spawner.RemoveAt(0);
                GameManager.Instance.SpawnFriendly5();
            }
        }
        if (friendly6Spawner.Count > 0)
        {
            if (time > friendly6Spawner[0])
            {
                friendly6Spawner.RemoveAt(0);
                GameManager.Instance.SpawnFriendly6();
            }
        }

        if (advanced2Spawner.Count > 0)
        {
            if (time > advanced2Spawner[0])
            {
                advanced2Spawner.RemoveAt(0);
                GameManager.Instance.SpawnAdvanced2();
            }
        }

        if (advanced3Spawner.Count > 0)
        {
            if (time > advanced3Spawner[0])
            {
                advanced3Spawner.RemoveAt(0);
                GameManager.Instance.SpawnAdvanced3();
            }
        }
        
        if (advanced4Spawner.Count > 0)
        {
            if (time > advanced4Spawner[0])
            {
                advanced3Spawner.RemoveAt(0);
                GameManager.Instance.SpawnAdvanced4();
            }
        }
    }
}
