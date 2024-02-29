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
        soundManager = GameObject.FindGameObjectWithTag("Sound").GetComponent<SoundManager>();    //�±װ� Sound�� SoundManager�� ����.
        bossHp = GetComponent<BossHp>();
    }

    private void Start()
    {
        //PlayerManager.instance.startPoint = transform.position;  // �÷��̾��� ���� ��ġ�� ����.
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
        // Trap ������ �÷��̾�� Die ����.
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
        // CheckPoint ���� �� checkPoint ���� ��ġ ����.
        PlayerManager.instance.startPoint = pos;
    }

    void Die()
    {
        //animationController.Hit();
        // �÷��̾ Die�Ǹ� Respawn ����.
        soundManager.PlaySFX(soundManager.DieSound);    // �׾��� �� �Ҹ� ����.
        ProjectileManager.Instance.dieEffect.Play();    // ��ƼŬ ����Ʈ ����.
        StartCoroutine(Respawn(0.5f));
        StartCoroutine(DontDie());

        Diescore++;
        DiescoreText.text = "Die : " + Diescore.ToString();
        DiescoreText2.text = Diescore.ToString();
    }

    IEnumerator Respawn(float duration)
    {
        playerRb.simulated = false;     //�÷��̾� ������ٵ� �ùķ���Ƽ�� ��� ��Ȱ��ȭ.
        playerRb.velocity = new Vector2(0, 0);      // �÷��̾� �ӵ� �缳��.
        transform.localScale = new Vector3(0, 0, 0);    // ������Ʈ�� ũ�⸦ 0,0,0���� ����(�Ⱥ���).
        yield return new WaitForSeconds(duration);      // duration �ð����� ��� ����.
        transform.position = PlayerManager.instance.startPoint;     // Respawn�Ǹ� startPos�� ��ġ �̵�.
        transform.localScale = new Vector3(2, 2, 2);       // ������Ʈ ũ�� ����.
        playerRb.simulated = true;      // �÷��̾� ������ٵ� �ùķ���Ƽ�� ��� Ȱ��ȭ.
    }

    IEnumerator DontDie()   // �÷��̾� ����.
    {
        gameObject.layer = 13;     // 12�� ���̾�� ����.
        yield return new WaitForSeconds(3.0f);    // ���� �ð�����.
        gameObject.layer = 8;      // 8�� ���̾�� ����.
    }
}