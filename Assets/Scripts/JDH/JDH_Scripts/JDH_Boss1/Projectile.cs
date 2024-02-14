using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            //Destroy(collision.gameObject);
           
            gameObject.SetActive(false);
            //Destroy(gameObject);
        }
        else if (collision.CompareTag("Boss"))
        {
            collision.GetComponent<BossHp>().TakeDamage(PlayerManager.instance.playerDamage);
            gameObject.SetActive(false);
            //Destroy(gameObject);
        }
        else if (collision.CompareTag("Boss2"))
        {
            collision.GetComponent<BossHp2>().TakeDamage(PlayerManager.instance.playerDamage);
            gameObject.SetActive(false);
            //Destroy(gameObject);
        }
        else if (collision.CompareTag("Ground"))
        {

            gameObject.SetActive(false);
            //Destroy(gameObject);
        }

    }
}
