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
                Debug.Log("HP����");
                StartCoroutine(Shield(itemNum));
                break;
            case 1://jump
                Debug.Log("��������");
                StartCoroutine(Jump(itemNum));
                break;
            case 2://speed
                Debug.Log("���ǵ�����");
                break;
            case 3://enchant
                Debug.Log("��þƮ����");
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
        Debug.Log(" ���� ���� ");
        PlayerManager.instance.FindPlayer().tag = "NonPlayer";
        yield return new WaitForSeconds(itemSO.shieldTime);
        Debug.Log(" ȿ�� ��");
        PlayerManager.instance.FindPlayer().tag = "Player";
    }
    IEnumerator Jump(ItemSO itemSO)
    {
        Debug.Log(" ���� ���� ");
        PlayerManager.instance.FindPlayer().GetComponent<PlayerInputController>().jumpForce += itemSO.jumpPower;
        yield return new WaitForSeconds(itemSO.jumpTime);
        Debug.Log(" ȿ�� ��");
        PlayerManager.instance.FindPlayer().GetComponent<PlayerInputController>().jumpForce -= itemSO.jumpPower;
    }
}
