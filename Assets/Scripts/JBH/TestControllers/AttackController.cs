using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackController : MonoBehaviour
{
    public float fireRate = 0.5f; // �ʴ� �߻� Ƚ��
    private float nextFireTime = 0f;
    public float arrowSpeed = 10f; // ȭ�� �ӵ�

    private PlayerAttackObjectPool objectPoolManager;

    private void Start()
    {
        objectPoolManager = FindObjectOfType<PlayerAttackObjectPool>();
    }

    private void Update()
    {
        // ���콺 ���� ��ư Ŭ���� ����
        if (Input.GetMouseButton(0) && Time.time >= nextFireTime)
        {
            Attack();
            nextFireTime = Time.time + fireRate;
        }
    }

    private void Attack()
    {
        // ���콺 ��ġ�� ȭ�� �߻�
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f;
        Vector3 direction = (mousePosition - transform.position).normalized;

        GameObject arrow = objectPoolManager.GetArrowFromPool();
        if (arrow != null)
        {
            arrow.transform.position = transform.position;
            arrow.SetActive(true);

            // ���� ����
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            arrow.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

            Rigidbody2D rb = arrow.GetComponent<Rigidbody2D>();
            rb.velocity = direction * arrowSpeed;
        }
    }
}