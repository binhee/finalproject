using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    PlayerRespawn playerRespawn;    // PlayerRespawn 스크립트에 엑세스
    SpriteRenderer spriteRenderer;
    public Sprite passive, active;

    private void Awake()
    {
        playerRespawn = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerRespawn>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // player가 CheckPoint를 터치하면, Respawn 위치 업데이트
        if (collision.CompareTag("Player"))
        {
            SoundManager.SoundInstance.PlaySFX(SoundManager.SoundInstance.CheckPoint);  // 체크 사운드 재생.
            playerRespawn.UpdateCheckPoint(transform.position);
            spriteRenderer.sprite = active;
        }
    }
}
