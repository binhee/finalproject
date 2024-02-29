using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;


public class Teleport : MonoBehaviour
{
    public GameObject targetObj;   // �̵��� ��� ������Ʈ
    public GameObject toObj;       // �̵��� ��ġ�� ������Ʈ
    public GameObject Boss;
    public GameObject mainCamera;
    public GameObject camera1;    // �ó׸ӽ� ī�޶�
    public GameObject camera2;
    public GameObject camera3;

    // Ʈ���� ������ �÷��̾ �������� �� ȣ��Ǵ� �޼���
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Boss.SetActive(true);
            targetObj = collision.gameObject;   // ��� ������Ʈ�� �÷��̾�� ����
            StartCoroutine(TeleportRoutine());   // �ڷ���Ʈ ��ƾ ����
        }
    }

    // Ʈ���� ������ �÷��̾ �ӹ��� �ִ� ���� ��� ȣ��Ǵ� �޼���
    //private void OnTriggerStay2D(Collider2D collision)
    //{
    //    if (collision.CompareTag("Player"))
    //    {
    //        //StartCoroutine(TeleportRoutine());   // �ڷ���Ʈ ��ƾ ����
    //    }
    //}

    // �ڷ���Ʈ�� �����ϴ� �ڷ�ƾ
    IEnumerator TeleportRoutine()
    {
        camera1.SetActive(false);
        
        //mainCamera.transform.position += new Vector3(100, 0, 0);
        yield return null;   // �� ������ ���
        targetObj.transform.position = toObj.transform.position;   // ��� ������Ʈ�� ��ǥ ��ġ�� �̵�

        camera3.SetActive(true);
        yield return null;
        camera3.SetActive(false);
        camera2.SetActive(true);
    }
}