using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
        else if (collision.CompareTag("Boss"))
        {
            collision.GetComponent<BossHp>().TakeDamage(PlayerManager.instance.playerDamage);
            Destroy(gameObject);
        }
        else if (collision.CompareTag("Boss2"))
            {
            collision.GetComponent<BossHp2>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
