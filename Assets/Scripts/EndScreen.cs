using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndScreen : MonoBehaviour
{
    [SerializeField] private Button playButton;
    [SerializeField] private AudioSource end;

    private void Start()
    {
        playButton.onClick.AddListener((() =>
        {
            SceneManager.LoadScene("FINALSCENE");
        }));
    }
}
