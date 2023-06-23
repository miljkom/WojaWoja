using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class SceneSystem : Singleton<SceneSystem>
{
    public event Action<Scene> SceneChangeStarted;
    public event Action<Scene> SceneChangeEnded;

    [SerializeField] private Image blackFader;

    private readonly float fadeDuration = 2f;
    private bool isFaded = false;

    protected override void Awake()
    {
        base.Awake();
    }

    public void LoadScene(Scene newScene)
    {
        SceneChangeStarted?.Invoke(newScene);

        InputSystem.Instance.DisableInputSystem("LoadScene");

        isFaded = false;
        blackFader.DOColor(Color.black, fadeDuration).OnComplete(() =>
        {
            isFaded = true;
        });
        StartCoroutine(LoadSceneAsync((int)newScene));

        SceneChangeEnded?.Invoke(newScene);
    }
    
    IEnumerator LoadSceneAsync(int sceneIndex)
    {
        yield return new WaitUntil(() => isFaded);

        SceneManager.LoadScene(sceneIndex);

        blackFader.DOColor(Color.clear, fadeDuration).OnComplete(() =>
        {
            InputSystem.Instance.EnableInputSystem("LoadScene");
        });
    }

    public Scene GetActiveScene()
    {
        return (Scene)SceneManager.GetActiveScene().buildIndex;
    }

    public bool IsActiveScene(Scene scene)
    {
        return GetActiveScene() == scene;
    }
}

public enum Scene
{
    Menu = 0,
    Game = 1
}