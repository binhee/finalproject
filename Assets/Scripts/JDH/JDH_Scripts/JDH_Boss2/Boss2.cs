using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Boss2State { MoveApeear =0, Pattern01, Pattern02, Pattern03 }
public class Boss2 : MonoBehaviour
{
    [SerializeField]
    private StageData stageData;
    
    private Boss2State boss2State = Boss2State.MoveApeear;
    private Movement2D movement2D;
    private BossHp2 bosshp2;

    private Boss2Weapon boss2Weapon;

    private void Awake()
    {
        movement2D = GetComponent<Movement2D>();
        bosshp2 = GetComponent<BossHp2>();
        boss2Weapon = GetComponent<Boss2Weapon>();

    }

    public void ChangePattern(Boss2State newstate)
    {
        StopCoroutine(boss2State.ToString());
        boss2State = newstate;
        StartCoroutine(boss2State.ToString());
    }

    private IEnumerator MoveApeear()
    {
        
        while (true)
        {
            movement2D.MoveTo(Vector3.zero);
            ChangePattern(Boss2State.Pattern01);
           
            yield return null;
        }
    }
    private IEnumerator Pattern01()
    {
        boss2Weapon.StartAttack(EnemyAttackType.Laser);

        while (true)
        {
            if (bosshp2.CurrentHP2 <= bosshp2.MaxHP2 * 0.7f)
            {
                boss2Weapon.StopAttack(EnemyAttackType.Laser);
                ChangePattern(Boss2State.Pattern02);
            }
            yield return null;
        }
    }
    private IEnumerator Pattern02()
    {
        boss2Weapon.StartAttack(EnemyAttackType.TriangleLaser);

        Vector3 direction = Vector3.left;
        movement2D.MoveTo(direction);

        while (true)
        {
            Debug.Log("a");
            if (transform.position.x <= stageData.LimitMin.x ||
                transform.position.x >= stageData.LimitMax.x)
            {
                Debug.Log("aa");
                direction *= -1;
                movement2D.MoveTo(direction);
                Debug.Log("aaa");
            }

            if (bosshp2.CurrentHP2 <= bosshp2.MaxHP2 * 0.4f)
            {
                boss2Weapon.StopAttack(EnemyAttackType.TriangleLaser);
                ChangePattern(Boss2State.Pattern03);
            }
            yield return null;
        }
    }

    private IEnumerator Pattern03()
    {
        boss2Weapon.StartAttack(EnemyAttackType.Boom);


        Vector3 direction = Vector3.left;
        movement2D.MoveTo(direction);

        while (true)
        {
            if (transform.position.x <= stageData.LimitMin.x ||
                transform.position.x >= stageData.LimitMax.x)
            {
                direction *= -1;
                movement2D.MoveTo(direction);
            }
            yield return null;
        }
    }
}

