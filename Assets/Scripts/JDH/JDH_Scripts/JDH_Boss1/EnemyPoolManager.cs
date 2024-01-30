using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPoolManager : MonoBehaviour
{
    public GameObject EnemysPrefab;
    public GameObject EnemyProjectilePrefab;
    public GameObject alertLinePrefab;
    public GameObject MeteoriteEnemyPrefab;

    public GameObject[] Enemys;
    public GameObject[] EnemyProjectile;
    public GameObject[] alertLine;
    public GameObject[] MeteoriteEnemy;

    public GameObject[] targetPool;

    private void Awake()
    {
        Enemys = new GameObject[10];
        EnemyProjectile = new GameObject[210];
        alertLine = new GameObject[10];
        MeteoriteEnemy = new GameObject[10];

        EnemyPool();
    }

    private void EnemyPool()
    {
        for(int i=0; i< Enemys.Length; i++)
        {
            Enemys[i]=Instantiate(EnemysPrefab);
            Enemys[i].SetActive(false);
        }
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
        switch(type)
        {
            case "Enemys":
                targetPool = Enemys;
                break;
            case "EnemyProjectile":
                targetPool = EnemyProjectile;
                break;
            case "alertLinePrefab":
                targetPool = alertLine;
                break;
            case "MeteoriteEnemy":
                targetPool = MeteoriteEnemy;
                break;

        }
        for(int i=0; i<targetPool.Length; i++)
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
    