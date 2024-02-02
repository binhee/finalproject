using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AttackType { CircleFire =0, SingleFireToCenterPosition }

public class BossWeapon : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyProjectile;
  
    public void StartFiring(AttackType attackType)
    {
        StartCoroutine(attackType.ToString());
    }

    public void StopFiring(AttackType attackType)
    {
        StopCoroutine(attackType.ToString());
    }

    private IEnumerator CircleFire()
    {
        float attackRate = 1f;
        int count = 30;
        float intervalAngle = 360 / count;
        float weightAngle = 0;

        while(true)
        {
            for(int i = 0; i < count; ++i)
            {
                GameObject clone = Instantiate(enemyProjectile,transform.position, Quaternion.identity);
                
                float angle = weightAngle+intervalAngle*i;
                float x = Mathf.Cos(angle * Mathf.PI / 180f);
                float y = Mathf.Sin(angle * Mathf.PI / 180f);

                clone.GetComponent<Movement2D>().MoveTo(new Vector2(x, y));
            }
            weightAngle += 1;
           

            yield return new WaitForSeconds(attackRate);
        }
    }

    private IEnumerator SingleFireToCenterPosition()
    {
        Vector3 targetPosition = Vector3.zero;
        float attackRate = 0.5f;

        while(true)
        {
            GameObject cloneLeft = Instantiate(enemyProjectile,transform.position, Quaternion.identity); 
            Vector3 Leftdirection = (targetPosition -cloneLeft.transform.position).normalized;
            cloneLeft.GetComponent<Movement2D>().MoveTo(Leftdirection);


            GameObject cloneRight = Instantiate(enemyProjectile, transform.position, Quaternion.identity);
            Vector3 Rightdirection = (targetPosition + cloneRight.transform.position).normalized;
            cloneRight.GetComponent<Movement2D>().MoveTo(Rightdirection);

            yield return new WaitForSeconds(attackRate);
        }
    }
}
