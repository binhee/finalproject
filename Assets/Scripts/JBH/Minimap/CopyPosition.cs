using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopyPosition : MonoBehaviour
{
    [SerializeField] private bool x, y, z;   // ������ ��ǥ �� ����
    [SerializeField] private Transform target;   // ���(Transform) ����

    private void Update()
    {
        if (!target) return;   // ����� null�̸� �Լ� ����

        // ������ ��ǥ �࿡ ���� ���� ����� ��ǥ�� ����
        transform.position = new Vector3(
            (x ? target.position.x : transform.position.x),
            (y ? target.position.y : transform.position.y),
            (z ? target.position.z : transform.position.z)
        );
    }
}
