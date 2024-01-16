using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDestroy : MonoBehaviour
{
    [SerializeField]
    StageData stageData;

    private float destroyLine = 7f;

    private void LateUpdate()
    {
        if(transform.position.y<stageData.LimitMin.y -destroyLine||
            transform.position.y>stageData.LimitMax.y +destroyLine||
            transform.position.x<stageData.LimitMin.x -destroyLine||
            transform.position.x>stageData.LimitMax.x +destroyLine)
        {
            Destroy(gameObject);
        }
    }
}
