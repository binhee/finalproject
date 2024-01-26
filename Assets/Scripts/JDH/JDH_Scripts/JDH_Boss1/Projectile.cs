using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private int damage = 500;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
        else if(collision.CompareTag("Boss"))
        {
            collision.GetComponent<BossHp>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
