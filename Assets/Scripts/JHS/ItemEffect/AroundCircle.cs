using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class AroundCircle : MonoBehaviour
{
    public float moveSpeed;
    public GameObject player;
    public Vector3 offset;
    void Update()
    {
        SetPosition();
        transform.position = player.transform.position + offset;
        transform.RotateAround(player.transform.position, Vector3.back, Time.deltaTime * moveSpeed);
        offset = transform.position - player.transform.position;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("BossProjectile"))//적 총알 태그 넣기
        {
            collision.gameObject.SetActive(false);
        }
    }
    void SetPosition()
    {
        if (player == null)
        {
            transform.rotation = new Quaternion(0, 0, 0, 0);
            player = PlayerManager.instance.FindPlayer();
            transform.position = player.transform.position + new Vector3(-2, 2, 0);
            offset = transform.position - player.transform.position;
        }
    }
}

