using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAction : ItemAction
{
    GameObject effect;
    public override void Use(ItemSO itemNum)
    {
        GameObject player = PlayerManager.instance.FindPlayer();
        effect = Instantiate(Inventory.instance.itemEffect[1], Inventory.instance.effectController.transform);
        effect.GetComponent<AroundCircle>().moveSpeed = 100;
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
