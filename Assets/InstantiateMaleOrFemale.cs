using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class InstantiateMaleOrFemale : MonoBehaviour
{
    [SerializeField] private List<GameObject> characters;

    private void Awake()
    {
        Instantiate(characters[Random.Range(0,characters.Count)], transform.position, quaternion.identity, transform);
    }
}
