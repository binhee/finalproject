using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmorAction : ItemAction
{
    GameObject effect;
    public override void Use(ItemSO itemNum)
    {
        GameObject player = PlayerManager.instance.FindPlayer();
        if (itemNum.itemType == ItemType.Helmet)
        {
            effect = Instantiate(Inventory.instance.itemEffect[2], player.transform);
        }
        else if (itemNum.itemType == ItemType.Armor)
        {
            player.GetComponent<CharacterStatsHandler>().CurrentStats.attackSO.speed += 10;
        }
        else if (itemNum.itemType == ItemType.Boots)
        {
            player.GetComponent<PlayerInputController>().itemDoubleJumping = true;
        }
    }
    public override void Delete()
    {
        Destroy(effect);
    }
    public void ResetArmor()
    {
        GameObject player = PlayerManager.instance.FindPlayer();
        player.GetComponent<CharacterStatsHandler>().CurrentStats.attackSO.speed -= 10;
    }
    public void ResetBoots()
    {
        GameObject player = PlayerManager.instance.FindPlayer();
        player.GetComponent<PlayerInputController>().itemDoubleJumping = false;
    }
    public override void Upgrade()
    {

    }
    public override void Mix()
    {

    }
}
