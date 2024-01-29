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
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "")//적 총알 태그 넣기
        {
            Destroy(collision);
        }
    }
}

