using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    //public AnimationController animationController;
    Rigidbody2D playerRb;
    ProjectileManager projectileManager;
    SoundManager soundManager;
    VolumeSettings volumeSettings;

    private void Awake()
    {
        playerRb = GetComponent<Rigidbody2D>();
        soundManager = GameObject.FindGameObjectWithTag("Sound").GetComponent<SoundManager>();    //태그가 Sound인 SoundManager에 접근.
    }

    private void Start()
    {
        //PlayerManager.instance.startPoint = transform.position;  // 플레이어의 시작 위치로 설정.
        transform.position = PlayerManager.instance.startPoint;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Trap 닿으면 플레이어는 Die 실행.
        if (collision.CompareTag("Trap"))
        {
            Die();
        }
        else if (collision.CompareTag("Meteorite"))
        {
            Die();
        }
        else if (collision.CompareTag("BossProjectile"))
        {
            Die();
        }
        else if (collision.CompareTag("Boss2Projectile"))
        {
            Die();
        }
        else if (collision.CompareTag("Boss"))
        {
            Die();
        }
        else if (collision.CompareTag("Boss2"))
        {
            Die();
        }

        else if (collision.CompareTag("Laser"))
        {
            Die();
        }
        else if (collision.CompareTag("Boss3Projectile"))
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
        //animationController.Hit();
        // 플레이어가 Die되면 Respawn 실행.
        soundManager.PlaySFX(soundManager.DieSound);    // 죽었을 때 소리 실행.
        ProjectileManager.Instance.dieEffect.Play();    // 파티클 이펙트 실행.
        StartCoroutine(Respawn(0.5f));
    }

    IEnumerator Respawn(float duration)
    {
        playerRb.simulated = false;     //플레이어 리지드바디 시뮬레이티드 기능 비활성화.
        playerRb.velocity = new Vector2(0, 0);      // 플레이어 속도 재설정.
        transform.localScale = new Vector3(0, 0, 0);    // 오브젝트의 크기를 0,0,0으로 만듬(안보임).
        yield return new WaitForSeconds(duration);      // duration 시간동안 잠시 정지.
        transform.position = PlayerManager.instance.startPoint;     // Respawn되면 startPos로 위치 이동.
        transform.localScale = new Vector3 (2, 2, 2);       // 오브젝트 크기 원복.
        playerRb.simulated = true;      // 플레이어 리지드바디 시뮬레이티드 기능 활성화.
    }
}
