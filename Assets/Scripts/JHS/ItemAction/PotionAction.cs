using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionAction : ItemAction
{
    public override void Use(ItemSO itemNum)
    {
        Inventory.instance.PotionUseAction(itemNum);
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
}
