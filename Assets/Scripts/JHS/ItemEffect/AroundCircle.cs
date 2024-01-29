using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AroundCircle : MonoBehaviour
{
    private Transform target;
    public float moveSpeed;
    private void Awake()
    {
        target = gameObject.transform.parent;
    }

    void Update()
    {
        transform.RotateAround(target.position,Vector3.back , -1 * Time.deltaTime * moveSpeed);
    }
}

