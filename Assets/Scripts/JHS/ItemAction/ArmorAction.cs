using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmorAction : ItemAction
{
    GameObject effect;
    public override void Use(ItemSO itemNum)
    {
        if (itemNum.itemType == ItemType.Helmet)
        {
            effect = Instantiate(Inventory.instance.itemEffect[2],Inventory.instance.effectController.transform);
        }
        else if (itemNum.itemType == ItemType.Armor)
        {
            PlayerManager.instance.playerProjectileAS = 20;
            //player.GetComponent<CharacterStatsHandler>().CurrentStats.attackSO.speed = 20;
        }
        else if (itemNum.itemType == ItemType.Boots)
        {
            PlayerManager.instance.isDoubleJump = true;
           //player.GetComponent<PlayerInputController>().itemDoubleJumping = true;
        }
    }
    public override void Delete()
    {
        Destroy(effect);
    }
    public void ResetArmor()
    {
        PlayerManager.instance.playerProjectileAS = 10;
        //player.GetComponent<CharacterStatsHandler>().CurrentStats.attackSO.speed -= 10;
    }
    public void ResetBoots()
    {
        GameObject player = PlayerManager.instance.FindPlayer();
        PlayerManager.instance.isDoubleJump = false;
        //  player.GetComponent<PlayerInputController>().itemDoubleJumping = false;
    }
    public override void Upgrade()
    {

    }
    public override void Mix()
    {

    }
}
