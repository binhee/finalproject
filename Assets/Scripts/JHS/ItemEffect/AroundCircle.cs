using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class AroundCircle : MonoBehaviour
{
    public float moveSpeed;
    public GameObject player;
    public Vector3 offset;
    private Vector3 startPos;
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
            player = PlayerManager.instance.FindPlayer();
            transform.position = player.transform.position + startPos;
            offset = transform.position - player.transform.position;
        }
    }
    public void PosbyGrade(int itemgrade)
    {
        switch (itemgrade)
        {
            case 0:
                startPos = new Vector3(-2, 2, 0);
                transform.rotation = Quaternion.Euler(0,0,0);
                break;
            case 1:
                startPos = new Vector3(2, 2, 0);
                transform.rotation = Quaternion.Euler(0, 0, -90);
                break;
            case 2:
                startPos = new Vector3(2, -2, 0);
                transform.rotation = Quaternion.Euler(0, 0, -180);
                break;
            case 3:
                startPos = new Vector3(-2, -2, 0);
                transform.rotation = Quaternion.Euler(0, 0, -270);
                break;
        }
   }
}

