using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimRotation : MonoBehaviour
{
    [SerializeField] private SpriteRenderer CharacterRenderer;   // ĳ���� SpriteRenderer ������Ʈ
    [SerializeField] private SpriteRenderer armRenderer;         // �� SpriteRenderer ������Ʈ
    [SerializeField] private Transform armPivot;                 // ���� ȸ�� �߽� ��

    private PlayerController _controller;   // PlayerController ��ũ��Ʈ

    private void Awake()
    {
        _controller = GetComponent<PlayerController>();   // PlayerController ��ũ��Ʈ ��������
    }

    void Start()
    {
        _controller.OnLookEvent += OnAim;   // �ٶ󺸱� �̺�Ʈ�� �ٶ󺸱� �Լ� ����
    }

    // �ٶ󺸱� �Լ�
    public void OnAim(Vector2 newAimDirection)
    {
        RotateArm(newAimDirection);   // ���� ȸ����Ű�� �Լ� ȣ��
    }

    // ���� �־��� �������� ȸ����Ű�� �Լ�
    private void RotateArm(Vector2 direction)
    {
        float rotZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;   // �־��� �������� ���� ���

        armRenderer.flipY = Mathf.Abs(rotZ) > 90f;   // ���� ������ ���� Sprite ������
        CharacterRenderer.flipX = armRenderer.flipY;   // ���� ������ �� ĳ���͵� ������
        armPivot.rotation = Quaternion.Euler(0, 0, rotZ);   // �� �߽� ���� �������� ȸ��
    }
}