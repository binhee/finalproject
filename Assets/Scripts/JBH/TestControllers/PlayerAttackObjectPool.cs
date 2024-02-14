using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackObjectPool : MonoBehaviour
{
    public GameObject arrowPrefab; // 발사체 프리팹
    public int poolSize = 20; // 풀 사이즈

    private GameObject[] arrowPool; // 발사체 풀 배열

    private void Start()
    {
        InitializeObjectPool(); // 발사체 풀 초기화
    }

    private void InitializeObjectPool()
    {
        // 발사체 풀 배열을 생성하고 초기화
        arrowPool = new GameObject[poolSize];
        for (int i = 0; i < poolSize; i++)
        {
            // 발사체 프리팹을 인스턴스화하여 발사체 풀에 추가
            arrowPool[i] = Instantiate(arrowPrefab, transform);
            // 발사체를 비활성화하여 풀에 저장
            arrowPool[i].SetActive(false);
        }
    }

    public GameObject GetArrowFromPool()
    {
        // 비활성화된 발사체를 찾아서 반환
        foreach (GameObject arrow in arrowPool)
        {
            if (!arrow.activeInHierarchy)
            {
                return arrow;
            }
        }
        return null; // 사용 가능한 발사체가 없는 경우 null 반환
    }
}
