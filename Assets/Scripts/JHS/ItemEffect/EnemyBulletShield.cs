using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletShield : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("BossProjectile"))//�� �Ѿ� �±� �ֱ�
        {
            collision.gameObject.SetActive(false);
        }
    }
}
