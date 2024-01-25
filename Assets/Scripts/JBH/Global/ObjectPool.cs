using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [System.Serializable]
    public struct Pool
    {
        public string tag;           // Ǯ�� �±�
        public GameObject prefab;    // Ǯ�� ���� ������
        public int size;             // Ǯ�� ũ��
    }

    public List<Pool> pools;         // ���� ������ ������Ʈ Ǯ�� �����ϴ� ����Ʈ
    public Dictionary<string, Queue<GameObject>> poolDictionary;   // �±׸� Ű�� ����Ͽ� ������Ʈ�� �����ϴ� ��ųʸ�

    private void Awake()
    {
        poolDictionary = new Dictionary<string, Queue<GameObject>>();   // ��ųʸ� �ʱ�ȭ

        // �� Ǯ�� ���� �ʱ�ȭ �۾� ����
        foreach (var pool in pools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();

            // Ǯ�� ũ�⸸ŭ ������Ʈ�� �����Ͽ� Ǯ�� �߰�
            for (int i = 0; i < pool.size; i++)
            {
                GameObject obj = Instantiate(pool.prefab);
                obj.SetActive(false);
                objectPool.Enqueue(obj);
            }

            // ��ųʸ��� Ǯ�� �±׸� Ű�� ����Ͽ� Ǯ�� �߰�
            poolDictionary.Add(pool.tag, objectPool);
        }
    }

    // ������ �±��� Ǯ���� ������Ʈ�� �����ִ� �޼���
    public GameObject SpawnFromPool(string tag)
    {
        // ��ųʸ��� �ش� �±װ� ������ null ��ȯ
        if (!poolDictionary.ContainsKey(tag))
            return null;

        // Ǯ���� ������Ʈ�� ������ ��ȯ�ϰ� �ٽ� Ǯ�� ����
        GameObject obj = poolDictionary[tag].Dequeue();
        poolDictionary[tag].Enqueue(obj);

        return obj;
    }
}