using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.VirtualTexturing;

public class Teleport : MonoBehaviour
{
    public GameObject targetObj;   // �̵��� ��� ������Ʈ
    public GameObject toObj;       // �̵��� ��ġ�� ������Ʈ
    public GameObject Boss;
    public GameObject mainCamera;

    // Ʈ���� ������ �÷��̾ �������� �� ȣ��Ǵ� �޼���
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            targetObj = collision.gameObject;   // ��� ������Ʈ�� �÷��̾�� ����
            StartCoroutine(TeleportRoutine());   // �ڷ���Ʈ ��ƾ ����
        }
    }

    // Ʈ���� ������ �÷��̾ �ӹ��� �ִ� ���� ��� ȣ��Ǵ� �޼���
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //StartCoroutine(TeleportRoutine());   // �ڷ���Ʈ ��ƾ ����
        }
    }

    // �ڷ���Ʈ�� �����ϴ� �ڷ�ƾ
    IEnumerator TeleportRoutine()
    {
        Boss.SetActive(true);
        mainCamera.transform.position += new Vector3(100, 0, 0);        
        yield return null;   // �� ������ ���
        targetObj.transform.position = toObj.transform.position;   // ��� ������Ʈ�� ��ǥ ��ġ�� �̵�
    }
}