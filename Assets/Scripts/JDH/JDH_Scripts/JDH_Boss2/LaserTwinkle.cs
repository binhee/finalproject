using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserTwinkle : MonoBehaviour
{
    private float fadeTime = 0.5f;
    private SpriteRenderer spriterenderer;

    private void Awake()
    {
        spriterenderer = GetComponent<SpriteRenderer>();

        StartCoroutine("TwinkleLoop");
    }

    private IEnumerator TwinkleLoop()
    {
        
            yield return StartCoroutine(FadeEffect(1, 0));
            yield return StartCoroutine(FadeEffect(1, 0));
        
    }

    private IEnumerator FadeEffect(float start, float end)
    {
        float currentTime = 0f;
        float percent = 0f;

        while (percent < 1)
        {
            currentTime += Time.deltaTime;
            percent = currentTime / fadeTime;

            Color color = spriterenderer.color;
            color.a = Mathf.Lerp(start, end, percent);
            spriterenderer.color = color;

            yield return null;

        }
    }
}
