using System;
using System.Collections.Generic;
using UnityEngine;

    public class GameManager: Singleton<GameManager>
    {

        [SerializeField] private List<GameObject> waypoints;
        private void Start()
        {
        }
    }
