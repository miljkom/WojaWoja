using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinScreen : MonoBehaviour
{
    [SerializeField] private AudioSource clip;

    private void Awake()
    {
        clip.Play();
    }

    private void Update()
    {
        if (Input.anyKeyDown && !clip.isPlaying)
        {
            Application.Quit();
        }
    }
}
