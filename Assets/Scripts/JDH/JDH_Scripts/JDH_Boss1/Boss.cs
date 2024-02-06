using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BossState { MoveToAppearPoint =0,Phase01, Phase02, Phase03}

public class Boss : MonoBehaviour
{
    [SerializeField]
    StageData stageData;
    [SerializeField]
    private GameObject explosionPrefab;
    [SerializeField]
    private float bossAppearPoint = 4f;
    private BossState bossState =BossState.MoveToAppearPoint;
    private Movement2D movement2D;
    private BossWeapon bossweapon;
    private BossHp bossHp;
    private PlayerController playerController;
    

    [SerializeField]
    private GameObject ClearPanel;
    [SerializeField]
    private GameObject GameOverPanel;
    [SerializeField]
    private int BossGold = 500;

    private void Awake()
    {
        playerController = GetComponent<PlayerController>();
        movement2D = GetComponent<Movement2D>();
        bossweapon = GetComponent<BossWeapon>();   
        bossHp = GetComponent<BossHp>();
       
    }

    public void ChangeState(BossState newState)
    {
        StopCoroutine(bossState.ToString());
        bossState = newState;
        StartCoroutine(bossState.ToString());   
    }

    private IEnumerator MoveToAppearPoint()
    {
        movement2D.MoveTo(Vector3.up);

        while(true)
        {
            if(transform.position.y>=bossAppearPoint)
            {
                movement2D.MoveTo(Vector3.zero);
                ChangeState(BossState.Phase01);
            }
            yield return null;
        }
    }
    
    private IEnumerator Phase01()
    {
        bossweapon.StartFiring(AttackType.CircleFire);

        while(true)
        {
            if (bossHp.CurrentHP <= bossHp.MaxHP * 0.7f)
            {
                bossweapon.StopFiring(AttackType.CircleFire);
                ChangeState(BossState.Phase02);
            }
            yield return null;
        }
    }

    private IEnumerator Phase02()
    {
        bossweapon.StartFiring(AttackType.SingleFireToCenterPosition);

        Vector3 direction = Vector3.up;
        movement2D.MoveTo(direction);

        while(true)
        {
            if(transform.position.y<=stageData.LimitMin.y||
                transform.position.y >=stageData.LimitMax.y)
            {
                direction *= -1;
                movement2D.MoveTo(direction);
            }

            if(bossHp.CurrentHP<=bossHp.MaxHP*0.3f)
            {
                bossweapon.StartFiring(AttackType.SingleFireToCenterPosition);
                ChangeState(BossState.Phase03);
            }
            yield return null;
        }
    }

    private IEnumerator Phase03()
    {
        bossweapon.StartFiring(AttackType.CircleFire);
        bossweapon.StartFiring(AttackType.SingleFireToCenterPosition);

        Vector3 direction = Vector3.up;
        movement2D.MoveTo(direction);

        while(true)
        {
            if (transform.position.y <= stageData.LimitMin.y ||
                transform.position.y >= stageData.LimitMax.y)
            {
                direction *= -1;
                movement2D.MoveTo(direction);
            }
            yield return null;
        }
    }
    public void OnDie()
    {
        Instantiate(explosionPrefab,transform.position,Quaternion.identity);
        ClearPanel.SetActive(true);
        PlayerManager.instance.playerGold += BossGold;
        //playerController.Gold += BossGold;
        PlayerPrefs.SetInt("Gold", PlayerManager.instance.playerGold);
        gameObject.SetActive(false);
    }
}
