using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animations : MonoBehaviour
{
    protected Animator animator;   // Animator 컴포넌트
    protected PlayerController controller;   // PlayerController 스크립트

    protected virtual void Awake()
    {
        animator = GetComponentInChildren<Animator>();   // 자식 객체 중 Animator 컴포넌트 가져오기
        controller = GetComponent<PlayerController>();   // PlayerController 스크립트 가져오기
    }
}