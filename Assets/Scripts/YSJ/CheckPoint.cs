using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    PlayerRespawn playerRespawn;    // PlayerRespawn ��ũ��Ʈ�� ������

    private void Awake()
    {
        playerRespawn = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerRespawn>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // player�� CheckPoint�� ��ġ�ϸ�, Respawn ��ġ ������Ʈ
        if (collision.CompareTag("Player"))
        {
            playerRespawn.UpdateCheckPoint(transform.position);
        }
    }
}
