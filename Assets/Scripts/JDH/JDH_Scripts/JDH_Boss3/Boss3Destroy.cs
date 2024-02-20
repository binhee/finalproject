using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss3Destroy : MonoBehaviour
{
    [SerializeField]
    StageData stageData;

    private float destroyLine = 12f;

    private void LateUpdate()
    {
        if (transform.position.y < stageData.LimitMin.y - destroyLine ||
            transform.position.y > stageData.LimitMax.y + destroyLine ||
            transform.position.x < stageData.LimitMin.x - destroyLine ||
            transform.position.x > stageData.LimitMax.x + destroyLine)
        {
            Destroy(gameObject);
        }
    }
}
