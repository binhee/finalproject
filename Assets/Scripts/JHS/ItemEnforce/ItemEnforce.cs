using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class ItemEnforce : MonoBehaviour
{
    private int grade;

    public GameObject enforceSlot;

    public Text enforceNameTxt;
    public Text enforceItemTxt;
    public Text enforceResultTxt;

    void Update()
    {
        Enforce();
    }
    void Enforce()
    {
        if (enforceSlot.transform.childCount == 1)
        {
            GameObject enforceItem = enforceSlot.transform.GetChild(0).gameObject;
            ClassifyItemGrade(enforceItem);
            EnforceItemByGrade();
            enforceNameTxt.text = enforceItem.GetComponent<DraggableUI>().itemNameTxt.text;
        }
        else
        {
            ResetEnforceItemText();
        }
    }
    void ClassifyItemGrade(GameObject item)
    {
        DraggableUI dragitem = item.GetComponent<DraggableUI>();
        if(dragitem.itemImageType==ItemType.HpPotion|| dragitem.itemImageType == ItemType.SpeedPotion||
            dragitem.itemImageType == ItemType.EnchantPotion || dragitem.itemImageType == ItemType.JumpPotion)
        {
            grade = item.GetComponent<PotionAction>().grade;
        }
        else if (dragitem.itemImageType == ItemType.Weapon)
        {
            grade = item.GetComponent<WeaponAction>().grade;
        }
        else if (dragitem.itemImageType == ItemType.Helmet|| dragitem.itemImageType == ItemType.Armor
            || dragitem.itemImageType == ItemType.Boots)
        {
            grade = item.GetComponent<ArmorAction>().grade;
        }
    }
    public void EnforceButton()
    {
        if (enforceSlot.transform.childCount == 1)
        {
            GameObject enforceItem = enforceSlot.transform.GetChild(0).gameObject;
            DraggableUI dragitem = enforceItem.GetComponent<DraggableUI>();
            if (dragitem.itemImageType == ItemType.HpPotion || dragitem.itemImageType == ItemType.SpeedPotion ||
            dragitem.itemImageType == ItemType.EnchantPotion || dragitem.itemImageType == ItemType.JumpPotion)
            {
                enforceItem.GetComponent<PotionAction>().grade++;
            }
            else if (dragitem.itemImageType == ItemType.Weapon)
            {
                enforceItem.GetComponent<WeaponAction>().grade++;
            }
            else if (dragitem.itemImageType == ItemType.Helmet || dragitem.itemImageType == ItemType.Armor
                || dragitem.itemImageType == ItemType.Boots)
            {
                enforceItem.GetComponent<ArmorAction>().grade++;
            }

        }
    }
    void EnforceItemByGrade()
    {
        float percent = 100 / (grade + 1);
        int cost = (grade + 1) * 200;
        enforceItemTxt.text = $"강화 단계 {grade} -> {grade + 1}\n강화 확률 {percent} %\n소모골드 {cost}";
    }
    void ResetEnforceItemText()
    {
        enforceNameTxt.text = "없음";
        enforceItemTxt.text = $"강화 단계 {0} -> {0+ 1}\n강화 확률 {0} %\n소모골드 {0}";
    }
}
