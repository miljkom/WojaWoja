using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class PostProcessingManager : PersistentSingleton<PostProcessingManager>
{
    [SerializeField] private Volume _postProcessingVolume;
    private Vignette _vignette;
    private ChromaticAberration _chromaticAberration;

    private void Start() 
    {
        _postProcessingVolume.profile.TryGet(out _vignette);
        _postProcessingVolume.profile.TryGet(out _chromaticAberration);
    }
    private IEnumerator VignetteController(float intensity, float duration)
    {
        float elapsedTime = 0f;
        _vignette.color.value = Color.red;
        while (elapsedTime < duration)
        {
            float currentValue = Mathf.Lerp(_vignette.intensity.value, intensity, elapsedTime / duration);
            _vignette.intensity.value = currentValue;
            elapsedTime += Time.deltaTime;
            yield return null;  
        }
        elapsedTime = 0f;
        while (elapsedTime < duration)
        {
            float currentValue = Mathf.Lerp(_vignette.intensity.value, 0, elapsedTime / duration);
            _vignette.intensity.value = currentValue;
            elapsedTime += Time.deltaTime;
            yield return null;  
        }
        _vignette.color.value = Color.black;
    }
    private IEnumerator ChromaticController(float intensity, float duration)
    {
        float elapsedTime = 0f;
        while (elapsedTime < duration)
        {
            float currentValue = Mathf.Lerp(_chromaticAberration.intensity.value, intensity, elapsedTime / duration);
            _chromaticAberration.intensity.value = currentValue;
            elapsedTime += Time.deltaTime;
            yield return null;  
        }
        elapsedTime = 0f;
        while (elapsedTime < duration)
        {
            float currentValue = Mathf.Lerp(_chromaticAberration.intensity.value, 0, elapsedTime / duration);
            _chromaticAberration.intensity.value = currentValue;
            elapsedTime += Time.deltaTime;
            yield return null;  
        }
    }
    public void VojaDamageEffect() {
            StartCoroutine(VignetteController(.5f,.175f));
            StartCoroutine(ChromaticController(.25f,.175f));
    }
}
