using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyAttackType { Laser = 0, TriangleLaser, Boom,TripleBoom }
public class Boss2Weapon : MonoBehaviour
{
    public Enemy2PoolManager Enemy2PoolManager;
    //public GameObject boss2Laser;
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

            //GameObject cloneLine = Instantiate(boss2Laser,transform.position,Quaternion.identity);

            yield return new WaitForSeconds(1f);

            // Destroy(cloneLine);

            GameObject Center = Enemy2PoolManager.MakeProjectiles("Boss2Projectile1");
            Center.transform.position = transform.position;
            GameObject LeftAttack = Enemy2PoolManager.MakeProjectiles("Boss2Projectile1");
            LeftAttack.transform.position = transform.position;
            LeftAttack.GetComponent<Movement2D>().MoveTo(new Vector3(-1f, -1, 0));
            GameObject RightAttack = Enemy2PoolManager.MakeProjectiles("Boss2Projectile1");
            RightAttack.transform.position = transform.position;
            RightAttack.GetComponent<Movement2D>().MoveTo(new Vector3(1f, -1, 0));

           
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
            cloneLaser.GetComponent<Movement2D>().MoveTo(new Vector3(0, -1, 0));

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

           
            yield return new WaitForSeconds(attackRate);

        }
    }

    private IEnumerator Boom()
    {
      
        while (true)
        {
            GameObject boom = Enemy2PoolManager.MakeProjectiles("Boss2ProjectileBoom");
            boom.transform.position = transform.position;
           
            Vector3 Targetdirection = (PlayerManager.instance.FindPlayer().transform.position - boom.transform.position).normalized;
            boom.GetComponent<Movement2D>().MoveTo(Targetdirection);

            float Time = Random.Range(1.5f, 2f);
            yield return new WaitForSeconds(Time);

            GameObject Effect = Enemy2PoolManager.MakeProjectiles("Boss2Boom");
            Effect.transform.position = boom.transform.position;
           
            boom.SetActive(false);

            yield return new WaitForSeconds(0.2f);
            
            Effect.SetActive(false);
           
        }
    }
    private IEnumerator TripleBoom()
    {

        while(true)
        {
            GameObject boom = Enemy2PoolManager.MakeProjectiles("Boss2ProjectileBoom");
            boom.transform.position = transform.position;
            boom.GetComponent<Movement2D>().MoveTo(new Vector3(0.5f, -1, 0));

            GameObject boom2 = Enemy2PoolManager.MakeProjectiles("Boss2ProjectileBoom");
            boom2.transform.position = transform.position;
            boom2.GetComponent<Movement2D>().MoveTo(new Vector3(-0.5f, -1, 0));

            float Time = Random.Range(0.5f,1f);
            yield return new WaitForSeconds(Time);

            GameObject Effect = Enemy2PoolManager.MakeProjectiles("Boss2Boom");
            Effect.transform.position = boom.transform.position; 
            GameObject Effect2 = Enemy2PoolManager.MakeProjectiles("Boss2Boom");
            Effect2.transform.position = boom2.transform.position;

            boom.SetActive(false);
            boom2.SetActive(false);

            yield return new WaitForSeconds(0.2f);

            Effect.SetActive(false);
            Effect2.SetActive(false);

        }
    }
}
