using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    

    private void Start()
    {
        //PlayerManager.instance.startPoint = transform.position;  // 플레이어의 시작 위치로 설정.
        Respawn();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Trap 닿으면 플레이어는 Die 실행.
        if(collision.CompareTag("Trap"))
        {
            Die();
        }
    }

    public void UpdateCheckPoint(Vector2 pos)
    {
        // CheckPoint 접촉 시 checkPoint 변수 위치 변경.
        PlayerManager.instance.startPoint = pos;
    }

    void Die()
    {
        // 플레이어가 Die되면 Respawn 실행.
        Respawn();
    }

    void Respawn()
    {
        // Respawn되면 startPos로 위치 이동.
        transform.position = PlayerManager.instance.startPoint;
    }
}
