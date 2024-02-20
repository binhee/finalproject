using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationTile : MonoBehaviour
{
    public Transform startPos;
    public Transform endPos;
    public Transform desPos;
    public float speed;

    void Start()
    {
        transform.position = startPos.position;
        desPos = endPos;
    }

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

    void FixedUpdate()
    {
        transform.position = Vector2.MoveTowards(transform.position, desPos.position, Time.deltaTime * speed);

        if (Vector2.Distance(transform.position, desPos.position) <= 0.05f)
        {
            // ���� ��ġ ���� �� ���� �̵� ������ ����
            if (desPos == endPos) desPos = startPos;
            else desPos = endPos;
        }
    }
}
