using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceAni : MonoBehaviour
{
    float time = 0;
    public float size = 5;
    public float upSizeTime = 0.2f;
    public float delayAni;


    void Update()
    {
        StartCoroutine("bounce");
    }
    IEnumerator bounce()
    {

        if (time <= upSizeTime)
        {
            transform.localScale = Vector3.one * (1 + size * time);
        }
        else if (time <= upSizeTime * 2)
        {
            transform.localScale = Vector3.one * (2 * size * upSizeTime + 1 - time * size);
        }
        else
        {
            transform.localScale = Vector3.one;
        }
        time += Time.deltaTime;

        if (upSizeTime*2 < time)
        {
            yield return new WaitForSeconds(delayAni);
            transform.localScale = Vector3.one;
            time = 0;
        }
    }
}
