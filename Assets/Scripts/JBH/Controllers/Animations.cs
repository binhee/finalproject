using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animations : MonoBehaviour
{
    protected Animator animator;   // Animator ������Ʈ
    protected PlayerController controller;   // PlayerController ��ũ��Ʈ

    protected virtual void Awake()
    {
        animator = GetComponentInChildren<Animator>();   // �ڽ� ��ü �� Animator ������Ʈ ��������
        controller = GetComponent<PlayerController>();   // PlayerController ��ũ��Ʈ ��������
    }
}