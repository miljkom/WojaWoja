using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WhiteHit : MonoBehaviour
{
    [SerializeField] List<SpriteRenderer> sprites = new List<SpriteRenderer>();
    [SerializeField] SpriteRenderer sprite;
    Material _material;
    void Start()
    {
        _material = sprite.material;
    }
    
    public IEnumerator PlayWhiteHit(float duration)
    {
        float intensity =  sprite.material.GetFloat("_Intensity");
        var elapsedTime = 0f;
        while(elapsedTime < duration)
        {
            float currentValue = Mathf.Lerp(intensity, 1, elapsedTime / duration);
            sprite.material.SetFloat("_Intensity", currentValue);
            yield return null;  
        }
        elapsedTime = 0f;
        while(elapsedTime < duration)
        {
            float currentValue = Mathf.Lerp(intensity, 0, elapsedTime / duration);
            sprite.material.SetFloat("_Intensity", currentValue);
            yield return null;  
        }
    }
}
