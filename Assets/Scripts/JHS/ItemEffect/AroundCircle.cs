using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AroundCircle : MonoBehaviour
{
    public float moveSpeed;
    public GameObject player;
    public Vector3 offset;
    private Vector3 startPos;

    public int grade;
    public GameObject[] circleSword;

    void Update()
    {
        if (grade >0)
        {
            SetPosition();
            transform.position = player.transform.position;
        }
        ActivebyGrade(grade);
        /* transform.position = player.transform.position + offset;
         transform.RotateAround(player.transform.position, Vector3.back, Time.deltaTime * moveSpeed);
         offset = transform.position - player.transform.position;*/

    }   

    void SetPosition()
    {
        if (player == null)
        {
            player = PlayerManager.instance.FindPlayer();
            //transform.position = player.transform.position + startPos;
           // offset = transform.position - player.transform.position;
        }
    }
    public void ActivebyGrade(int itemgrade)
    {
        /*switch (itemgrade)
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
         }*/
        switch (grade)
        {
            case 0:
                circleSword[0].SetActive(false);
                circleSword[1].SetActive(false);
                circleSword[2].SetActive(false);
                circleSword[3].SetActive(false);
                break;
            case 1:
                circleSword[0].SetActive(true);
                break;
                case 2:
                circleSword[0].SetActive(true);
                circleSword[1].SetActive(true);
                break;
                case 3:
                circleSword[0].SetActive(true);
                circleSword[1].SetActive(true);
                circleSword[2].SetActive(true);
                break;
                case 4:
                circleSword[0].SetActive(true);
                circleSword[1].SetActive(true);
                circleSword[2].SetActive(true);
                circleSword[3].SetActive(true);
                break;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("BossProjectile"))//적 총알 태그 넣기
        {
            collision.gameObject.SetActive(false);
        }
    }
}

