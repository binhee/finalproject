using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [System.Serializable]
    public struct Pool
    {
        public string tag;           // 풀의 태그
        public GameObject prefab;    // 풀에 사용될 프리팹
        public int size;             // 풀의 크기
    }

    public List<Pool> pools;         // 여러 종류의 오브젝트 풀을 관리하는 리스트
    public Dictionary<string, Queue<GameObject>> poolDictionary;   // 태그를 키로 사용하여 오브젝트를 관리하는 딕셔너리

    private void Awake()
    {
        poolDictionary = new Dictionary<string, Queue<GameObject>>();   // 딕셔너리 초기화

        // 각 풀에 대해 초기화 작업 수행
        foreach (var pool in pools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();

            // 풀의 크기만큼 오브젝트를 생성하여 풀에 추가
            for (int i = 0; i < pool.size; i++)
            {
                GameObject obj = Instantiate(pool.prefab);
                obj.SetActive(false);
                objectPool.Enqueue(obj);
            }

            // 딕셔너리에 풀의 태그를 키로 사용하여 풀을 추가
            poolDictionary.Add(pool.tag, objectPool);
        }
    }

    // 지정된 태그의 풀에서 오브젝트를 꺼내주는 메서드
    public GameObject SpawnFromPool(string tag)
    {
        // 딕셔너리에 해당 태그가 없으면 null 반환
        if (!poolDictionary.ContainsKey(tag))
            return null;

        // 풀에서 오브젝트를 꺼내어 반환하고 다시 풀에 넣음
        GameObject obj = poolDictionary[tag].Dequeue();
        poolDictionary[tag].Enqueue(obj);

        return obj;
    }
}