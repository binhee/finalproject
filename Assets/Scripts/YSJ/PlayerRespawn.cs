using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    

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
    }

    public void UpdateCheckPoint(Vector2 pos)
    {
        // CheckPoint ���� �� checkPoint ���� ��ġ ����.
        PlayerManager.instance.startPoint = pos;
    }

    void Die()
    {
        // �÷��̾ Die�Ǹ� Respawn ����.
        Respawn();
    }

    void Respawn()
    {
        // Respawn�Ǹ� startPos�� ��ġ �̵�.
        transform.position = PlayerManager.instance.startPoint;
    }
}
