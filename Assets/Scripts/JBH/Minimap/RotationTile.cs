using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationTile : MonoBehaviour
{
    public float rotationSpeed = 1.0f; // �����̼� �ӵ� ������ ���� ����

    void Update()
    {
        // Ÿ���� ���� �����̼� ���� ����
        Vector3 currentRotation = transform.rotation.eulerAngles;

        // y ���� �������� �����̼� ���� ��� ������
        currentRotation.z += rotationSpeed * Time.deltaTime;

        // ���ο� �����̼� ���� ����
        transform.rotation = Quaternion.Euler(currentRotation);
    }
}
