using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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


    [SerializeField]
    private GameObject ClearPanel;
   
    [SerializeField]
    private int BossGold = 500;

    private void Awake()
    {
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
        
        while (true)
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
        SoundManager.SoundInstance.PlaySFX(SoundManager.SoundInstance.Boss1Pattern1Sound);
        while (true)
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
        SoundManager.SoundInstance.PlaySFX(SoundManager.SoundInstance.Boss1Pattern2Sound);
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
        SoundManager.SoundInstance.PlaySFX(SoundManager.SoundInstance.Boss1Pattern3Sound);
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
        UnlockStage();
        SoundManager.SoundInstance.PlaySFX(SoundManager.SoundInstance.Boss1Die);
        Instantiate(explosionPrefab,transform.position,Quaternion.identity);
        
        ClearPanel.SetActive(true);
        PlayerManager.instance.playerGold += BossGold;
      
        PlayerPrefs.SetInt("Gold", PlayerManager.instance.playerGold);
        gameObject.SetActive(false);
        Time.timeScale = 0;
    }

    public void UnlockStage()   // 스테이지 버튼 언락 함수.
    {
        if (SceneManager.GetActiveScene().buildIndex >= PlayerPrefs.GetInt("ReachedIndex"))
        {
            PlayerPrefs.SetInt("ReachedIndex", SceneManager.GetActiveScene().buildIndex + 1);
            PlayerPrefs.SetInt("UnlockedLevel", PlayerPrefs.GetInt("UnlockedLevel", 1) + 1);
            PlayerPrefs.Save();
        }
    }
}
