using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TMPColor : MonoBehaviour
{
    [SerializeField]
    private float lerpTime = 0.1f;
    private TextMeshProUGUI BossText;

    private void Awake()
    {
        BossText = GetComponent<TextMeshProUGUI>();
    }

    private void OnEnable()
    {
        StartCoroutine("ColorLerpLoop");
    }

    private IEnumerator ColorLerpLoop()
    {
        while (true)
        {
            yield return StartCoroutine(ColorLerp(Color.white, Color.red));
            yield return StartCoroutine(ColorLerp(Color.red, Color.white));
        }
    }

    private IEnumerator ColorLerp(Color startColor,Color endColor)
    {
        float currentTime = 0f;
        float percent = 0f;

        while (percent<1)
        {
            currentTime += Time.deltaTime;
            percent = currentTime / lerpTime;

            BossText.color = Color.Lerp(startColor, endColor, percent);

            yield return null;
        }
    }
}
