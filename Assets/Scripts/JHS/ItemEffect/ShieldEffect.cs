using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldEffect : MonoBehaviour
{
    public GameObject spinObject;
    public float rotateSpeed;
    void Update()
    {
        spinObject.transform.Rotate(0, 0, -Time.deltaTime * rotateSpeed, Space.Self);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "")//적 총알 태그 넣기
        {
            Destroy(collision);
        }
    }
}
