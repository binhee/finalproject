using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Boss2State { MoveApeear =0, Pattern01, Pattern02 }
public class Boss2 : MonoBehaviour
{
    [SerializeField]
    private StageData stageData;
    [SerializeField]
    private float boss2Appear = 5f;

    private Boss2State boss2State = Boss2State.MoveApeear;
    private Movement2D movement2D;
    private BossHp bosshp;

    private Boss2Weapon boss2Weapon;

    private void Awake()
    {
        movement2D = GetComponent<Movement2D>();
        bosshp = GetComponent<BossHp>();
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
        movement2D.MoveTo(Vector3.down);
        while (true)
        {
            if (transform.position.y >= boss2Appear)
            {
                movement2D.MoveTo(Vector3.zero);
                ChangePattern(Boss2State.Pattern01);
            }
            yield return null;
        }
    }
    private IEnumerator Pattern01()
    {
        boss2Weapon.StartAttack(EnemyAttackType.Laser);
        
        while (true)
        {
            if (bosshp.CurrentHP <= bosshp.MaxHP * 0.7f)
            {
                boss2Weapon.StopAttack(EnemyAttackType.Laser);
            }
            yield return null;
        }
    }
}
