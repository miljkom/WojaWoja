using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WhiteHit : MonoBehaviour
{
    [SerializeField] List<SpriteRenderer> sprites = new List<SpriteRenderer>();

    public IEnumerator PlayWhiteHit(float duration)
    {
        float intensity = 0f;
        var elapsedTime = 0f;
        while(elapsedTime < duration)
        {
            float currentValue = Mathf.Lerp(intensity, 1, elapsedTime / duration);
            foreach (var sprite in sprites)
            {
                sprite.material.SetFloat("_Intensity", currentValue);
            }
            elapsedTime += Time.deltaTime;
            yield return null;  
        }
        elapsedTime = 0f;
        while(elapsedTime < duration)
        {
            float currentValue = Mathf.Lerp(intensity, 0, elapsedTime / duration);
            foreach (var sprite in sprites)
            {
                sprite.material.SetFloat("_Intensity", currentValue);
            }
            elapsedTime += Time.deltaTime;
            yield return null;  
        }
    }
}
