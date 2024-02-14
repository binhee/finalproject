using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackObjectPool : MonoBehaviour
{
    public GameObject arrowPrefab; // �߻�ü ������
    public int poolSize = 20; // Ǯ ������

    private GameObject[] arrowPool; // �߻�ü Ǯ �迭

    private void Start()
    {
        InitializeObjectPool(); // �߻�ü Ǯ �ʱ�ȭ
    }

    private void InitializeObjectPool()
    {
        // �߻�ü Ǯ �迭�� �����ϰ� �ʱ�ȭ
        arrowPool = new GameObject[poolSize];
        for (int i = 0; i < poolSize; i++)
        {
            // �߻�ü �������� �ν��Ͻ�ȭ�Ͽ� �߻�ü Ǯ�� �߰�
            arrowPool[i] = Instantiate(arrowPrefab, transform);
            // �߻�ü�� ��Ȱ��ȭ�Ͽ� Ǯ�� ����
            arrowPool[i].SetActive(false);
        }
    }

    public GameObject GetArrowFromPool()
    {
        // ��Ȱ��ȭ�� �߻�ü�� ã�Ƽ� ��ȯ
        foreach (GameObject arrow in arrowPool)
        {
            if (!arrow.activeInHierarchy)
            {
                return arrow;
            }
        }
        return null; // ��� ������ �߻�ü�� ���� ��� null ��ȯ
    }
}
