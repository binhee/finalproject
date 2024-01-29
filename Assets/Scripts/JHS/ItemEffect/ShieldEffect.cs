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
}
