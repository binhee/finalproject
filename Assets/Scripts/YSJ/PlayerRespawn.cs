using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerRespawn : MonoBehaviour
{
    //public AnimationController animationController;
    Rigidbody2D playerRb;
    ProjectileManager projectileManager;

    private void Awake()
    {
        playerRb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        //PlayerManager.instance.startPoint = transform.position;  // �÷��̾��� ���� ��ġ�� ����.
        transform.position = PlayerManager.instance.startPoint;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Trap ������ �÷��̾�� Die ����.
        if(collision.CompareTag("Trap"))
        {
            Die();
        }
        else if(collision.CompareTag("Meteorite"))
            {
            Die();
        }
        else if(collision.CompareTag("BossProjectile"))
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
        ProjectileManager.Instance.dieEffect.Play();    // ��ƼŬ ����Ʈ ����.
        StartCoroutine(Respawn(0.5f));
    }

    IEnumerator Respawn(float duration)
    {
        playerRb.simulated = false;     //�÷��̾� ������ٵ� �ùķ���Ƽ�� ��� ��Ȱ��ȭ.
        transform.localScale = new Vector3(0, 0, 0);    // ������Ʈ�� ũ�⸦ 0,0,0���� ����(�Ⱥ���).
        yield return new WaitForSeconds(duration);      // duration �ð����� ��� ����.
        transform.position = PlayerManager.instance.startPoint;     // Respawn�Ǹ� startPos�� ��ġ �̵�.
        transform.localScale = new Vector3 (2, 2, 2);       // ������Ʈ ũ�� ����.
        playerRb.simulated = true;      // �÷��̾� ������ٵ� �ùķ���Ƽ�� ��� Ȱ��ȭ.
    }

    
}
