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
    }
    public override void Delete()
    {
        Destroy(effect);
    }
    public override void Upgrade()
    {

    }
    public override void Mix()
    {

    }
}
