using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    PlayerRespawn playerRespawn;    // PlayerRespawn 스크립트에 엑세스

    private void Awake()
    {
        playerRespawn = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerRespawn>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // player가 CheckPoint를 터치하면, Respawn 위치 업데이트
        if (collision.CompareTag("Player"))
        {
            playerRespawn.UpdateCheckPoint(transform.position);
        }
    }
}
