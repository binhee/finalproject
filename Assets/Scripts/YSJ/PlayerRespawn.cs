using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    //public AnimationController animationController;

    private void Start()
    {        
        //PlayerManager.instance.startPoint = transform.position;  // �÷��̾��� ���� ��ġ�� ����.
        Respawn();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Trap ������ �÷��̾�� Die ����.
        if(collision.CompareTag("Trap"))
        {
            Die();
        }
        else if(collision.CompareTag("Meteorite"))
            {
            Die();
        }
        else if(collision.CompareTag("BossProjectile"))
        {
            Die();
        }
    }

    public void UpdateCheckPoint(Vector2 pos)
    {
        // CheckPoint ���� �� checkPoint ���� ��ġ ����.
        PlayerManager.instance.startPoint = pos;
    }

    void Die()
    {
        //animationController.Hit();
        // �÷��̾ Die�Ǹ� Respawn ����.
        Respawn();
    }

    void Respawn()
    {
        // Respawn�Ǹ� startPos�� ��ġ �̵�.
        transform.position = PlayerManager.instance.startPoint;
    }
}
