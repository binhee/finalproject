using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyAttackType { Laser = 0, TriangleLaser, Boom }
public class Boss2Weapon : MonoBehaviour
{
    public Enemy2PoolManager Enemy2PoolManager;

    [SerializeField]
    private float attackRate;

    public void StartAttack(EnemyAttackType enemyAttackType)
    {
        StartCoroutine(enemyAttackType.ToString());
    }

    public void StopAttack(EnemyAttackType enemyAttackType)
    {
        StopCoroutine(enemyAttackType.ToString());
    }

    private IEnumerator Laser()
    {   

        while (true)
        {

            //GameObject Line = Instantiate(LaserLine, new Vector3(0, -4, 0), Quaternion.identity);
            GameObject cloneLine = Enemy2PoolManager.MakeProjectiles("Boss2Laser");
            cloneLine.transform.position = transform.position;
            
            yield return new WaitForSeconds(1f);
            Debug.Log("¿Ö¾ÈµÅ");
            cloneLine.SetActive(false);
            //Destroy(Line);

            GameObject Center = Enemy2PoolManager.MakeProjectiles("Boss2Projectile1");
            Center.transform.position = transform.position;
            GameObject LeftAttack = Enemy2PoolManager.MakeProjectiles("Boss2Projectile1");
            LeftAttack.transform.position = transform.position;
            LeftAttack.GetComponent<Movement2D>().MoveTo(new Vector3(-1f, -1, 0));
            GameObject RightAttack = Enemy2PoolManager.MakeProjectiles("Boss2Projectile1");
            RightAttack.transform.position = transform.position;
            RightAttack.GetComponent<Movement2D>().MoveTo(new Vector3(1f, -1, 0));

            //GameObject LeftcloneLaser = Enemy2PoolManager.MakeProjectiles("Boss2Projectile2");
            //LeftcloneLaser.transform.position = transform.position + Vector3.left * 1f;

            //GameObject RightcloneLaser = Enemy2PoolManager.MakeProjectiles("Boss2Projectile3");
            //RightcloneLaser.transform.position = transform.position + Vector3.right * 1f;

            //GameObject LeftcloneLaser = Enemy2PoolManager.MakeProjectiles("Boss2Projectile1");
            //LeftcloneLaser.GetComponent<Movement2D>().MoveTo(new Vector3(-0.4f, 0, 0));
           

            //GameObject RightcloneLaser = Enemy2PoolManager.MakeProjectiles("Boss2Projectile1");
            //RightcloneLaser.GetComponent<Movement2D>().MoveTo(new Vector3(0.4f, 0, 0));
            //GameObject RightCloneLaser = Enemy2PoolManager.MakeProjectiles("Boss2Projectile3");
            //RightCloneLaser.GetComponent<Movement2D>().MoveTo(new Vector3(1f, -1, 0));

            //Instantiate(Enemylaser[0], transform.position, Quaternion.identity);
            //cloneLaser = Instantiate(Enemylaser[1], transform.position, Quaternion.identity);
            //cloneLaser.GetComponent<Movement2D>().MoveTo(new Vector3(-1f, -1, 0));
            //cloneLaser = Instantiate(Enemylaser[2], transform.position, Quaternion.identity);
            //cloneLaser.GetComponent<Movement2D>().MoveTo(new Vector3(1f, -1, 0));

            Debug.Log("Laser");

            yield return new WaitForSeconds(attackRate);
           
        }
    }

    private IEnumerator TriangleLaser()
    {
       
        while (true)
        {

            yield return new WaitForSeconds(1f);

            GameObject cloneLaser = Enemy2PoolManager.MakeProjectiles("Boss2Projectile2");
            cloneLaser.transform.position = transform.position;

            GameObject halfLeftClone = Enemy2PoolManager.MakeProjectiles("Boss2Projectile2");
            halfLeftClone.transform.position = transform.position;
            halfLeftClone.GetComponent<Movement2D>().MoveTo(new Vector3(-0.5f, -1, 0));

            GameObject halfRightClone = Enemy2PoolManager.MakeProjectiles("Boss2Projectile2");
            halfRightClone.transform.position = transform.position;
            halfRightClone.GetComponent<Movement2D>().MoveTo(new Vector3(0.5f, -1, 0));

            GameObject LeftClone = Enemy2PoolManager.MakeProjectiles("Boss2Projectile2");
            LeftClone.transform.position = transform.position;
            LeftClone.GetComponent<Movement2D>().MoveTo(new Vector3(-1, -1, 0));

            GameObject RightClone = Enemy2PoolManager.MakeProjectiles("Boss2Projectile2");
            RightClone.transform.position = transform.position;
            RightClone.GetComponent<Movement2D>().MoveTo(new Vector3(1, -1, 0));

            Debug.Log("Laser1");


            yield return new WaitForSeconds(attackRate);

        }
    }

    private IEnumerator Boom()
    {
        GameObject boom = null;
        GameObject Effect = null;
        while (true)
        {
            //Instantiate(boomPrefab, transform.position, Quaternion.identity);

            //boom = Instantiate(boomPrefab, transform.position, Quaternion.identity);
            boom = Enemy2PoolManager.MakeProjectiles("Boss2ProjectileBoom");
            boom.transform.position = transform.position;
            //boom.GetComponent<Movement2D>().MoveTo(new Vector3(0, -6, 0));

            yield return new WaitForSeconds(1f);

            Effect = Enemy2PoolManager.MakeProjectiles("Boss2Boom");
            Effect.transform.position = boom.transform.position;
            boom.SetActive(false);

            //Effect = Instantiate(boomEffect, boom.transform.position, Quaternion.identity);
            //Destroy(boom);

            yield return new WaitForSeconds(attackRate);
            Effect.SetActive(false);


        }
    }
}
