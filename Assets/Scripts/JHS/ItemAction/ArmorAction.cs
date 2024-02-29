using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmorAction : ItemAction
{
    public List<GameObject> effects = new List<GameObject>();
    GameObject effect;
    public override void Use(ItemSO itemNum)
    {
        if (itemNum.itemType == ItemType.Helmet)
        {
            for (int i = 0; i <= grade; i++)
            {
                effect = Instantiate(Inventory.instance.itemEffect[2], Inventory.instance.effectController.transform);
                effect.GetComponent<SubArrowLauncher>().PosByGrade(i);
                effects.Add(effect);
            }
        }
        else if (itemNum.itemType == ItemType.Armor)
        {
            PlayerManager.instance.playerProjectileAS = 20+(5*grade);
        }
        else if (itemNum.itemType == ItemType.Boots)
        {
            PlayerManager.instance.isDoubleJump = true;
        }
    }
    public override void Delete()
    {
        for (int i = 0; i < effects.Count; i++)
        {
            Destroy(effects[i]);
        }
        effects.Clear();
        if (gameObject.GetComponent<Item>().itemType == ItemType.Armor)
        {
            ResetArmor();
        }
        else if(gameObject.GetComponent<Item>().itemType == ItemType.Boots)
        {
            ResetBoots();
        }
    }
    public void ResetArmor()
    {
        PlayerManager.instance.playerProjectileAS = 10;
    }
    public void ResetBoots()
    {
        PlayerManager.instance.isDoubleJump = false;
    }
    public override void Upgrade()
    {
        grade++;
    }
    public override void Mix()
    {

    }
}
