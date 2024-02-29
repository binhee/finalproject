using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class PlayerRespawn : MonoBehaviour
{
    //public AnimationController animationController;
    Rigidbody2D playerRb;
    ProjectileManager projectileManager;
    SoundManager soundManager;
    VolumeSettings volumeSettings;
    BossHp bossHp;

    public Text DiescoreText;
    public Text DiescoreText2;
    private int Diescore = 0;
    public GameObject DieScoreText;
    public GameObject NoJumping;

    private void Awake()
    {
        playerRb = GetComponent<Rigidbody2D>();
        soundManager = GameObject.FindGameObjectWithTag("Sound").GetComponent<SoundManager>();    //태그가 Sound인 SoundManager에 접근.
        bossHp = GetComponent<BossHp>();
    }

    private void Start()
    {
        //PlayerManager.instance.startPoint = transform.position;  // 플레이어의 시작 위치로 설정.
        transform.position = PlayerManager.instance.startPoint;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("NoJumping"))
        {
            NoJumping.SetActive(true);
        }

        else if (collision.gameObject.CompareTag("floor"))
        {
            DieScoreText.SetActive(true);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("NoJumping"))
        {
            NoJumping.SetActive(false);
        }
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
            Debug.Log("0");
            bossHp.BossHpHeal(50f);
            Die();
        }
        else if (collision.CompareTag("BossProjectile"))
        {
            Debug.Log("0");
            bossHp.BossHpHeal(50f);
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
        StartCoroutine(DontDie());

        Diescore++;
        DiescoreText.text = "Die : " + Diescore.ToString();
        DiescoreText2.text = Diescore.ToString();
    }

    IEnumerator Respawn(float duration)
    {
        playerRb.simulated = false;     //플레이어 리지드바디 시뮬레이티드 기능 비활성화.
        playerRb.velocity = new Vector2(0, 0);      // 플레이어 속도 재설정.
        transform.localScale = new Vector3(0, 0, 0);    // 오브젝트의 크기를 0,0,0으로 만듬(안보임).
        yield return new WaitForSeconds(duration);      // duration 시간동안 잠시 정지.
        transform.position = PlayerManager.instance.startPoint;     // Respawn되면 startPos로 위치 이동.
        transform.localScale = new Vector3(2, 2, 2);       // 오브젝트 크기 원복.
        playerRb.simulated = true;      // 플레이어 리지드바디 시뮬레이티드 기능 활성화.
    }

    IEnumerator DontDie()   // 플레이어 무적.
    {
        gameObject.layer = 13;     // 12번 레이어로 변경.
        yield return new WaitForSeconds(3.0f);    // 일정 시간동안.
        gameObject.layer = 8;      // 8번 레이어로 변경.
    }
}