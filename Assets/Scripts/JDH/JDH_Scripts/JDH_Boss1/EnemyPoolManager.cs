using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPoolManager : MonoBehaviour
{
    public GameObject EnemysPrefab;
    public GameObject EnemyProjectilePrefab;
    public GameObject alertLinePrefab;
    public GameObject MeteoriteEnemyPrefab;

   
    private GameObject[] EnemyProjectile;
    private GameObject[] alertLine;
    private GameObject[] MeteoriteEnemy;

    private GameObject[] targetPool;

    private void Awake()
    {
       
        EnemyProjectile = new GameObject[240];
        alertLine = new GameObject[10];
        MeteoriteEnemy = new GameObject[10];

        EnemyPool();
    }

    private void EnemyPool()
    {
       
        for (int i = 0; i < EnemyProjectile.Length; i++)
        {
            EnemyProjectile[i] = Instantiate(EnemyProjectilePrefab);
            EnemyProjectile[i].SetActive(false);
        }
        for (int i = 0; i < alertLine.Length; i++)
        {
            alertLine[i] = Instantiate(alertLinePrefab);
            alertLine[i].SetActive(false);
        }
        for (int i = 0; i < MeteoriteEnemy.Length; i++)
        {
            MeteoriteEnemy[i] = Instantiate(MeteoriteEnemyPrefab);
            MeteoriteEnemy[i].SetActive(false);
        }       
    }

    public GameObject MakeObj(string type)
    {
        switch (type)
        {
           
            case "EnemyProjectile":
                targetPool = EnemyProjectile;
                break;
            case "alertLine":
                targetPool = alertLine;
                break;
            case "MeteoriteEnemy":
                targetPool = MeteoriteEnemy;
                break;

        }
        for (int i = 0; i < targetPool.Length; i++)
        {

            if (!targetPool[i].gameObject.activeSelf)
            {
                targetPool[i].gameObject.SetActive(true);
                return targetPool[i];
            }
        }
        return null;
    }
}
    