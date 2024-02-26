using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using static PotionControl;
using Unity.VisualScripting;
using System;

public class PotionControl : MonoBehaviour
{
    [System.Serializable]
    public class Potion
    {
        public KeyCode key;
        public int indexNum;
        public int itemIndexNum;
        public bool onPotionEquip;
        public Image potionImage;
        public Text cooldownText;
        public float cooldownTime = 5f;
        public bool isOnCooldown = false;
        public float cooldownTimer;
        public PotionAction potionAction;
        public ItemSO ItemSO;
    }

    public List<Potion> potions;
    public GameObject[] potionObject = new GameObject[4];
    void Start()
    {
        // �ʱ�ȭ �� UI ������Ʈ
        foreach (var potion in potions)
        {
            // ���� �̹��� �ʱ�ȭ
            potion.potionImage = potion.potionImage ?? GetComponent<Image>();

            // ���� �� �ؽ�Ʈ �ʱ�ȭ
            potion.cooldownText = potion.cooldownText ?? GetComponentInChildren<Text>();

            if (potion.cooldownText == null)
            {

            }
        }
    }

    void Update()
    {
        // ���� ������Ʈ
        foreach (var potion in potions)
        {
            if (potion.isOnCooldown)
            {
                UpdateCooldownUI(potion);
            }
            UPdatePotionImage(potion);
            // Ű �Է� �� ���� ���
            if (Input.GetKeyDown(potion.key))
            {
                UsePotion(potion);
            }
        }
    }
    void UPdatePotionImage(Potion potionNum)
    {
        int num = potionNum.indexNum;
        if (Inventory.instance.potionEquipSlots[num].transform.childCount == 0 && potionNum.onPotionEquip)
        {
            potionNum.onPotionEquip = false;
            Destroy(potionObject[num]);
        }
        if (Inventory.instance.potionEquipSlots[num].transform.childCount == 1 && !potionNum.onPotionEquip)
        {
            potionNum.onPotionEquip = true;
            potionObject[num] = Instantiate(Inventory.instance.potionEquipSlots[num].transform.GetChild(0).gameObject, gameObject.transform.GetChild(num));
            potionObject[num].GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);
            potionNum.potionAction = potionObject[num].GetComponent<PotionAction>();
            potionNum.ItemSO = potionObject[num].GetComponent<DraggableUI>().itemSO;
            potionNum.itemIndexNum = potionObject[num].GetComponent<DraggableUI>().itemIDNUM;

            /*GameObject item = Instantiate(Inventory.instance.potionEquipSlots[num].transform.GetChild(0).gameObject, gameObject.transform.GetChild(num));
           item.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);
            potionNum.potionAction = item.GetComponent<PotionAction>();
            potionNum.ItemSO = item.GetComponent<DraggableUI>().itemSO;
            potionNum.itemIndexNum = item.GetComponent<DraggableUI>().itemIDNUM;*/
        }
    }
    // ���� ��� �޼���
    void UsePotion(Potion potion)
    {
        if (!potion.isOnCooldown && potion.potionAction != null)
        {
            // ���� ��� �� �� ���
            potion.potionAction.Use(potion.ItemSO);
            Inventory.instance.potionEquipSlots[potion.indexNum].transform.GetChild(0).GetComponent<DraggableUI>().itemCount--;
            Inventory.instance.potionEquipSlots[potion.indexNum].transform.GetChild(0).GetComponent<DraggableUI>().UpdateText();
            potionObject[potion.indexNum].GetComponent<DraggableUI>().itemCount--;
            potionObject[potion.indexNum].GetComponent<DraggableUI>().UpdateText();
            StartCoroutine(PotionCooldown(potion));
        }
        else
        {
            Debug.Log("��ų ���� ��� ��");
        }
    }

    // ���� �� ��� �ð� ó��
    IEnumerator PotionCooldown(Potion potion)
    {
        potion.isOnCooldown = true;

        Color originalColor = potion.potionImage.color;
        Color targetColor = new Color(0.3f, 0.3f, 0.3f, 1f);  // ���� �̹��� ��Ӱ� ����

        potion.cooldownTimer = potion.cooldownTime;  // ���� ���ð� �ʱ�ȭ

        while (potion.cooldownTimer > 0f)
        {
            potion.cooldownTimer -= Time.deltaTime;

            float colorInterpolation = 1 - (potion.cooldownTimer / potion.cooldownTime);
            potion.potionImage.color = Color.Lerp(targetColor, originalColor, colorInterpolation);

            UpdateCooldownUI(potion);
            yield return null;
        }

        // ���� ���� ������ �ʱ�ȭ
        potion.isOnCooldown = false;
        // ���� �̹��� �������� ����
        potion.potionImage.color = Color.white;

        yield return null;
    }

    // ���� �� �ߤ� UI ������Ʈ
    void UpdateCooldownUI(Potion potion)
    {
        if (potion.potionImage == null)
        {
            return;
        }

        float cooldownPercentage = Mathf.Clamp01(1 - (potion.cooldownTimer / Mathf.Max(potion.cooldownTime, 0.01f)));
        // ���� �̹����� ���� ��� �ð� ǥ��
        potion.potionImage.fillAmount = cooldownPercentage;

        // ������ ��Ÿ�� �� ���� �ؽ�Ʈ ǥ��
        if (potion.isOnCooldown)
        {
            if (potion.cooldownTimer > 0f)
            {
                // ���� ���� �ð��� �ؽ�Ʈ�� ǥ��
                //potion.cooldownText.text = Mathf.CeilToInt(potion.cooldownTimer).ToString();
            }
            else
            {
                //potion.cooldownText.text = null;  // �ؽ�Ʈ �����
                // Debug.Log("���� ����");
            }
        }
    }
}
