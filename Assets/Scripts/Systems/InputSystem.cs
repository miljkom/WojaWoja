using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using System;

public class InputSystem : Singleton<InputSystem>
{
    private EventSystem eventSystem = EventSystem.current;
    private List<string> disableRequests = new List<string>();

    [SerializeField] private GameObject loadingScreenBlocker;

    public bool IsDisabled => disableRequests.Count > 0;
    
    protected override void Awake()
    {
        base.Awake();
    }
    
    public void DisableInputSystem(string request)
    {
        if (!disableRequests.Contains(request))
        {
            disableRequests.Add(request);
        }
        
        CheckInputSystem();
    }

    public void EnableInputSystem(string request)
    {
        if (disableRequests.Contains(request))
        {
            disableRequests.Remove(request);
        }
        
        CheckInputSystem();
    }
    
    public void ForceEnableInputSystem()
    {
        disableRequests = new List<string>();
        
        CheckInputSystem();
    }

    public void CheckInputSystem()
    {
        loadingScreenBlocker.SetActive(IsDisabled);
    }
}