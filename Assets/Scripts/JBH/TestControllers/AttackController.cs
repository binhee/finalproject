using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackController : MonoBehaviour
{
    public float arrowSpeed = 10f; // 화살 속도

    private PlayerAttackObjectPool objectPoolManager;

    private void Start()
    {
        objectPoolManager = FindObjectOfType<PlayerAttackObjectPool>();
    }

    private void Update()
    {
        // 마우스 왼쪽 버튼 클릭시 공격
        if (Input.GetMouseButtonDown(0))
        {
            Attack();
        }
    }

    private void Attack()
    {
        // 마우스 위치로 화살 발사
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f; // 2D 공간에서는 Z 값을 조절해야 합니다.
        Vector3 direction = (mousePosition - transform.position).normalized;

        GameObject arrow = objectPoolManager.GetArrowFromPool();
        if (arrow != null)
        {
            arrow.transform.position = transform.position;
            arrow.SetActive(true);

            // 방향 설정
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            arrow.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

            Rigidbody2D rb = arrow.GetComponent<Rigidbody2D>();
            rb.velocity = direction * arrowSpeed;
        }
    }
}