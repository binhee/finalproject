using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Boss3State { Pattern01, Pattern02 };

public class Boss3 : MonoBehaviour
{
    private Boss3State boss3State = Boss3State.Pattern01;
    [SerializeField]
    private StageData stageData;
    
    private Boss3HP boss3hp;
    private Boss3Weapon boss3Weapon;
    private Movement2D movement2D;
    

    private void Awake()
    {
        movement2D = GetComponent<Movement2D>();
        boss3hp = GetComponent<Boss3HP>();
        boss3Weapon = GetComponent<Boss3Weapon>();
    }

    public void ChangePattern(Boss3State newstate)
    {
        StopCoroutine(boss3State.ToString());
        boss3State = newstate;
        StartCoroutine(boss3State.ToString());
    }
   

    private IEnumerator Pattern01()
    {
        Debug.Log("aa");
        boss3Weapon.StartAttack(Boss3AttackType.SingleToPlayer);
        while(true)
        {
            if(boss3hp.CurrentHP3<=boss3hp.MaxHP3*0.7)
            {
                boss3Weapon.StopAttack(Boss3AttackType.SingleToPlayer);
                ChangePattern(Boss3State.Pattern02);
            }
            yield return null;
        }
    }

    private IEnumerator Pattern02()
    {
        boss3Weapon.StartAttack(Boss3AttackType.CircleForPlayer);
        while (true)
        {
            if(boss3hp.CurrentHP3<=boss3hp.MaxHP3*0.4)
            {
                boss3Weapon.StopAttack(Boss3AttackType.CircleForPlayer);
                
            }
            yield return null;
        }
    }
}
