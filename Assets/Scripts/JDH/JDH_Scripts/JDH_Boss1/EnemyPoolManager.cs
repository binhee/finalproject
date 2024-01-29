using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPoolManager : MonoBehaviour
{
    public GameObject EnemysPrefab;
    public GameObject EnemyProjectilePrefab;
    public GameObject alertLinePrefab;
    public GameObject MeteoriteEnemyPrefab;

    private GameObject[] Enemys;
    private GameObject[] EnemyProjectile;
    private GameObject[] alertLine;
    private GameObject[] MeteoriteEnemy;

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
}
    