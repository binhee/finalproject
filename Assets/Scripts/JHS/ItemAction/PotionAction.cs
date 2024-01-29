using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionAction : ItemAction
{
    public override void Use(ItemSO itemNum)
    {
        switch (itemNum.itemIDNum)
        {
            case 0://hp
                Debug.Log("HP포션");
                StartCoroutine(Shield(itemNum));
                break;
            case 1://jump
                Debug.Log("점프포션");
                StartCoroutine(Jump(itemNum));
                break;
            case 2://speed
                Debug.Log("스피드포션");
                break;
            case 3://enchant
                Debug.Log("인첸트포션");
                break;
        }
    }
    public override void Delete()
    {

    }
    public override void Upgrade()
    {

    }
    public override void Mix()
    {

    }

    IEnumerator Shield(ItemSO itemSO)
    {
        Debug.Log(" 쉴드 포션 ");
        PlayerManager.instance.FindPlayer().tag = "NonPlayer";
        yield return new WaitForSeconds(itemSO.shieldTime);
        Debug.Log(" 효과 끝");
        PlayerManager.instance.FindPlayer().tag = "Player";
    }
    IEnumerator Jump(ItemSO itemSO)
    {
        Debug.Log(" 점프 포션 ");
        PlayerManager.instance.FindPlayer().GetComponent<PlayerInputController>().jumpForce += itemSO.jumpPower;
        yield return new WaitForSeconds(itemSO.jumpTime);
        Debug.Log(" 효과 끝");
        PlayerManager.instance.FindPlayer().GetComponent<PlayerInputController>().jumpForce -= itemSO.jumpPower;
    }
}
