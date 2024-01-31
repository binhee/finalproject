using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossProjectile : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            gameObject.SetActive(false);
            //Destroy(gameObject);
        }
        else if(collision.CompareTag("Ground"))
        {
            gameObject.SetActive(false);
            //Destroy(gameObject);
        }
        else if(collision.CompareTag("Trap"))
        {
            gameObject.SetActive(false);
            //Destroy(gameObject) ;
        }
    }
}
