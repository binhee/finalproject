using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionAction : ItemAction
{
    public  override void Use(ItemSO itemNum)
    {
        switch (itemNum.itemIDNum)
        {
            case 0://hp
                StartCoroutine(Shield(itemNum));
                break;
            case 1://jump
                StartCoroutine(Jump(itemNum));
                break;
            case 2://speed
                StartCoroutine(Speed(itemNum));
                break;
            case 3://enchant
                StartCoroutine(Enchant(itemNum));
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
        GameObject player = PlayerManager.instance.FindPlayer();

        Debug.Log(" ���� ���� ");
        GameObject effect = Instantiate(Inventory.instance.itemEffect[0], player.transform);
        player.tag = "NonPlayer";
        yield return new WaitForSeconds(itemSO.shieldTime);
        Destroy(effect);
        Debug.Log(" ȿ�� ��");
        player.tag = "Player";
    }
    IEnumerator Jump(ItemSO itemSO)
    {
        PlayerInputController playerJump = PlayerManager.instance.FindPlayer().GetComponent<PlayerInputController>();

        Debug.Log(" ���� ���� ");
        playerJump.jumpForce += itemSO.jumpPower;
        yield return new WaitForSeconds(itemSO.jumpTime);
        Debug.Log(" ȿ�� ��");
        playerJump.jumpForce -= itemSO.jumpPower;
    }
    IEnumerator Speed(ItemSO itemSO)
    {
        CharacterStatsHandler playerHandler = PlayerManager.instance.FindPlayer().GetComponent<CharacterStatsHandler>();
        Debug.Log(" �ӵ� ���� ");
        playerHandler.CurrentStats.speed += itemSO.speedPower;
        yield return new WaitForSeconds(itemSO.speedTime);
        Debug.Log(" ȿ�� �� ");
        playerHandler.CurrentStats.speed -= itemSO.speedPower;
    }
    IEnumerator Enchant(ItemSO itemSO)
    {
        Debug.Log(" ��ȭ ���� ");
        PlayerManager.instance.playerDamage += itemSO.enchantPower;
        yield return new WaitForSeconds(itemSO.enchantTime);
        Debug.Log(" ȿ�� �� ");
        PlayerManager.instance.playerDamage -= itemSO.enchantPower;
    }
}
