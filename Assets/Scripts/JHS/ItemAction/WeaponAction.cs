using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAction : ItemAction
{
     public List<GameObject> effects = new List<GameObject>();
    GameObject effect;
    public override void Use(ItemSO itemNum)
    {
        GameObject player = PlayerManager.instance.FindPlayer();
        for(int i=0; i<=grade; i++)
        {
            effect = Instantiate(Inventory.instance.itemEffect[1], Inventory.instance.effectController.transform);
            effects.Add(effect);
            effect.GetComponent<AroundCircle>().moveSpeed = 100;
            effect.GetComponent<AroundCircle>().PosbyGrade(i);
        }
    }
    public override void Delete()
    {
        for(int i=0; i<effects.Count;i++)
        {
            Destroy(effects[i]);
        }
        effects.Clear();
    }
    public override void Upgrade()
    {
        grade++;
    }
    public override void Mix()
    {

    }
}
