using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy2PoolManager : MonoBehaviour
{
    public GameObject Boss2BoomPrefab;
    public GameObject Boss2ProjectileBoomPrefab;
    public GameObject Boss2Projectile1Prefab;
    public GameObject Boss2Projectile2Prefab;
    public GameObject Boss2Projectile3Prefab;
    public GameObject Boss2Projectile4Prefab;
    public GameObject Boss2Projectile5Prefab;
    public GameObject Boss2LaserPrefab;

    public GameObject[] Boss2Boom;
    public GameObject[] Boss2ProjectileBoom;
    public GameObject[] Boss2Projectile1;
    public GameObject[] Boss2Projectile2;
    public GameObject[] Boss2Projectile3;
    public GameObject[] Boss2Projectile4;
    public GameObject[] Boss2Projectile5;
    public GameObject[] Boss2Laser;
   

    public GameObject[] targetPool;


    private void Awake()
    {
        Boss2Boom = new GameObject[3];
        Boss2ProjectileBoom = new GameObject[3];
        Boss2Projectile1 = new GameObject[3];
        Boss2Projectile2 = new GameObject[3];
        Boss2Projectile3 = new GameObject[3];
        Boss2Projectile4 = new GameObject[3];
        Boss2Projectile5 = new GameObject[3];
        Boss2Laser = new GameObject[3];

        BossProjectiles();
    }

    private void BossProjectiles()
    {
        for(int i = 0;i<Boss2Boom.Length;++i)
        {
            Boss2Boom[i] = Instantiate(Boss2BoomPrefab);
            Boss2Boom[i].SetActive(false);
        }
        for(int i =0; i< Boss2ProjectileBoom.Length;++i)
        {
            Boss2ProjectileBoom[i] = Instantiate(Boss2ProjectileBoomPrefab);
            Boss2ProjectileBoom[i].SetActive(false);
        }

        for(int i=0; i<Boss2Projectile1.Length;++i)
        {
            Boss2Projectile1[i] = Instantiate(Boss2Projectile1Prefab);
            Boss2Projectile1[i].SetActive(false);
        }

        for(int i =0; i<Boss2Projectile2.Length;++i)
        {
            Boss2Projectile2[i] = Instantiate(Boss2Projectile2Prefab);
            Boss2Projectile2[i].SetActive(false);
        }

        for(int i =0; i<Boss2Projectile3.Length;++i)
        {
            Boss2Projectile3[i] = Instantiate (Boss2Projectile3Prefab);
            Boss2Projectile3[i].SetActive(false);
        }

        for(int i =0; i<Boss2Projectile4.Length;++i)
        {
            Boss2Projectile4[i] = Instantiate(Boss2Projectile4Prefab);
            Boss2Projectile4[i].SetActive(false);
        }
        
        for(int i = 0; i<Boss2Projectile5.Length;++i)
        {
            Boss2Projectile5[i] = Instantiate(Boss2Projectile5Prefab);
            Boss2Projectile5[i].SetActive(false);
        }

        for(int i=0; i<Boss2Laser.Length;++i)
        {
            Boss2Laser[i] = Instantiate(Boss2LaserPrefab);
            Boss2Laser[i] .SetActive(false);
        }
    }
    public GameObject MakeProjectiles(string type)
    {
        switch (type)
        {
            case "Boss2Boom":
                targetPool = Boss2Boom;
                break;
            case "Boss2ProjectileBoom":
                targetPool = Boss2ProjectileBoom;
                break;
            case "Boss2Projectile1":
                targetPool = Boss2Projectile1;
                break;
            case "Boss2Projectile2":
                targetPool = Boss2Projectile2;
                break;
            case "Boss2Projectile3":
                targetPool = Boss2Projectile3;
                break;
            case "Boss2Projectile4":
                targetPool = Boss2Projectile4;
                break;
            case "Boss2Projectile5":
                targetPool = Boss2Projectile5;
                break;
            case "Boss2Laser":
                targetPool = Boss2Laser;
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
