using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class PoolManager : MonoBehaviour
{
    public static PoolManager poolinstance { get; private set; }

    public Dictionary<string, GameObject[]> poolObject = new Dictionary<string, GameObject[]>();

    [Header("-----------Boss1------------")]
    public GameObject boss1projectile;
    public GameObject[] Boss1Projectile;
    public GameObject[] alertLine;
    public GameObject[] MeteoriteEnemy;

    [Header("-----------Boss2------------")]
    public GameObject[] Boss2Projectile1;
    public GameObject[] Boss2Projectile2;
    public GameObject[] Boss2Projectile3;
    public GameObject[] Boss2Boom;
    private void Start()
    {
        poolinstance = this;

        Boss1Object();
        
    }

    public void Boss1Object()
    {
        Boss1Projectile = new GameObject[220];
        alertLine = new GameObject[10];
        MeteoriteEnemy = new GameObject[10];

        poolObject.Add("Boss1Projectile", Boss1Projectile);
        poolObject.Add("AlertLine", alertLine);
        poolObject.Add("MeteoriteEnemy", MeteoriteEnemy);
        
    }

    public void Boss2Object()
    {
        Boss2Projectile1 = new GameObject[20];
        Boss2Projectile2 = new GameObject[70];
        Boss2Projectile3 = new GameObject[5];
        Boss2Boom = new GameObject[5];

        poolObject.Add("Boss2Projectile1", Boss2Projectile1);
        poolObject.Add("Boss2Projectile2", Boss2Projectile2);
        poolObject.Add("Boss2Projectile3", Boss2Projectile3);
        poolObject.Add("Boss2Boom", Boss2Boom);
    }

    public void Boss3Object()
    {

    }
}
