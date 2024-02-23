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
        soundManager = GameObject.FindGameObjectWithTag("Sound").GetComponent<SoundManager>();    //�±װ� Sound�� SoundManager�� ����.
    }

    private void Start()
    {
        //PlayerManager.instance.startPoint = transform.position;  // �÷��̾��� ���� ��ġ�� ����.
        transform.position = PlayerManager.instance.startPoint;
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
    }

    IEnumerator Respawn(float duration)
    {
        playerRb.simulated = false;     //�÷��̾� ������ٵ� �ùķ���Ƽ�� ��� ��Ȱ��ȭ.
        playerRb.velocity = new Vector2(0, 0);      // �÷��̾� �ӵ� �缳��.
        transform.localScale = new Vector3(0, 0, 0);    // ������Ʈ�� ũ�⸦ 0,0,0���� ����(�Ⱥ���).
        yield return new WaitForSeconds(duration);      // duration �ð����� ��� ����.
        transform.position = PlayerManager.instance.startPoint;     // Respawn�Ǹ� startPos�� ��ġ �̵�.
        transform.localScale = new Vector3 (2, 2, 2);       // ������Ʈ ũ�� ����.
        playerRb.simulated = true;      // �÷��̾� ������ٵ� �ùķ���Ƽ�� ��� Ȱ��ȭ.
    }
}
