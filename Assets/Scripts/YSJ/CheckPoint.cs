using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    PlayerRespawn playerRespawn;    // PlayerRespawn ��ũ��Ʈ�� ������
    SpriteRenderer spriteRenderer;
    public Sprite passive, active;

    private void Awake()
    {
        playerRespawn = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerRespawn>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // player�� CheckPoint�� ��ġ�ϸ�, Respawn ��ġ ������Ʈ
        if (collision.CompareTag("Player"))
        {
            SoundManager.SoundInstance.PlaySFX(SoundManager.SoundInstance.CheckPoint);  // üũ ���� ���.
            playerRespawn.UpdateCheckPoint(transform.position);
            spriteRenderer.sprite = active;
        }
    }
}
