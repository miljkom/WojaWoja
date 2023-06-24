using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class EnemySpawner : MonoBehaviour
{
    [FormerlySerializedAs("advancedSpawner")] [SerializeField] private List<float> advanced1Spawner;
    [SerializeField] private List<float> advanced2Spawner;
    [SerializeField] private List<float> advanced3Spawner;
    [SerializeField] private List<float> normalSpawner;

    private void Update()
    {
        var time = Time.timeSinceLevelLoad;
        if (time > advanced1Spawner[0])
        {
            advanced1Spawner.RemoveAt(0);
            GameManager.Instance.SpawnAdvanced1();
        }

        //ovo je normal, jbg nmg da menjam sada
        if (time > advanced2Spawner[0])
        {
            advanced2Spawner.RemoveAt(0);
            GameManager.Instance.SpawnNormal();
        }
        
        
        // if (time > advanced2Spawner[0])
        // {
        //     advanced2Spawner.RemoveAt(0);
        //     GameManager.Instance.SpawnAdvanced2();
        // }
        //
        // if (time > advanced3Spawner[0])
        // {
        //     advanced3Spawner.RemoveAt(0);
        //     GameManager.Instance.SpawnAdvanced3();
        // }
    }
}
