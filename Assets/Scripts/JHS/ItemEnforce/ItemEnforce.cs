using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ItemEnforce : MonoBehaviour
{
    private int grade;

    public GameObject enforceSlot;

    public TextMeshProUGUI enforceNameTxt;
    public TextMeshProUGUI enforceItemTxt;
    public TextMeshProUGUI enforceResultTxt;

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
            if(grade == 3)
            {
                MaxEnforceItemByGrade();
            }
            else
            {
                EnforceItemByGrade();
            }
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
        if (enforceSlot.transform.childCount == 1&& enforceSlot.transform.GetChild(0).gameObject.GetComponent<ItemAction>().grade < 3)
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
        enforceItemTxt.text = $"��ȭ �ܰ� {grade} -> {grade + 1}\n��ȭ Ȯ�� {percent} %\n�Ҹ��� {cost}";
    }
    void MaxEnforceItemByGrade()
    {
        enforceItemTxt.text = $"��ȭ�ܰ� = {grade}\n��ȭ �ܰ谡 �Ѱ�ġ�� �����߽��ϴ�.";
    }
    void ResetEnforceItemText()
    {
        enforceNameTxt.text = "����";
        enforceItemTxt.text = $"��ȭ �ܰ� {0} -> {0+ 1}\n��ȭ Ȯ�� {0} %\n�Ҹ��� {0}";
    }
}
