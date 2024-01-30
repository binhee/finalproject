using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.VirtualTexturing;

public class Teleport : MonoBehaviour
{
    public GameObject targetObj;   // 이동할 대상 오브젝트
    public GameObject toObj;       // 이동할 위치의 오브젝트
    public GameObject Boss;
    public GameObject mainCamera;

    // 트리거 영역에 플레이어가 진입했을 때 호출되는 메서드
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            targetObj = collision.gameObject;   // 대상 오브젝트를 플레이어로 설정
            StartCoroutine(TeleportRoutine());   // 텔레포트 루틴 시작
        }
    }

    // 트리거 영역에 플레이어가 머물러 있는 동안 계속 호출되는 메서드
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //StartCoroutine(TeleportRoutine());   // 텔레포트 루틴 시작
        }
    }

    // 텔레포트를 수행하는 코루틴
    IEnumerator TeleportRoutine()
    {
        Boss.SetActive(true);
        mainCamera.transform.position += new Vector3(100, 0, 0);        
        yield return null;   // 한 프레임 대기
        targetObj.transform.position = toObj.transform.position;   // 대상 오브젝트를 목표 위치로 이동
    }
}