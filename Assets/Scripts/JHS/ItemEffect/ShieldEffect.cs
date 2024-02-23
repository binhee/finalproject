using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldEffect : MonoBehaviour
{
    public GameObject spinObject;
    public float rotateSpeed;
    public GameObject player;
    void Update()
    {
        SetPosition();
        spinObject.transform.Rotate(0, 0, -Time.deltaTime * rotateSpeed, Space.Self);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("BossProjectile"))//적 총알 태그 넣기
        {
            collision.gameObject.SetActive(false);
        }
        if (collision.CompareTag("Boss2Projectile"))//적 총알 태그 넣기
        {
            collision.gameObject.SetActive(false);
        }
        if (collision.CompareTag("Boss3Projectile"))//적 총알 태그 넣기
        {
            collision.gameObject.SetActive(false);
        }
    }
    void SetPosition()
    {
        if (player == null)
        {
            player = PlayerManager.instance.FindPlayer();
        }
        transform.position = player.transform.position;
    }
}
