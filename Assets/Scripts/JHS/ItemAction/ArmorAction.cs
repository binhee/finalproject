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
            effect = Instantiate(Inventory.instance.itemEffect[3], player.transform);
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
    public override void Upgrade()
    {

    }
    public override void Mix()
    {

    }
}
