using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackObjectPool : MonoBehaviour
{
    public GameObject arrowPrefab;
    public int poolSize = 20; // 풀 사이즈

    private GameObject[] arrowPool;

    private void Start()
    {
        InitializeObjectPool();
    }

    private void InitializeObjectPool()
    {
        arrowPool = new GameObject[poolSize];
        for (int i = 0; i < poolSize; i++)
        {
            arrowPool[i] = Instantiate(arrowPrefab, transform);
            arrowPool[i].SetActive(false);
        }
    }

    public GameObject GetArrowFromPool()
    {
        foreach (GameObject arrow in arrowPool)
        {
            if (!arrow.activeInHierarchy)
            {
                return arrow;
            }
        }
        return null;
    }
}
