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
        // 초기화 시 UI 업데이트
        foreach (var potion in potions)
        {
            // 포션 이미지 초기화
            potion.potionImage = potion.potionImage ?? GetComponent<Image>();

            // 포션 쿨 텍스트 초기화
            potion.cooldownText = potion.cooldownText ?? GetComponentInChildren<Text>();

            if (potion.cooldownText == null)
            {

            }
        }
    }

    void Update()
    {
        // 포션 업데이트
        foreach (var potion in potions)
        {
            if (potion.isOnCooldown)
            {
                UpdateCooldownUI(potion);
            }
            UPdatePotionImage(potion);
            // 키 입력 시 포션 사용
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
    // 포션 사용 메서드
    void UsePotion(Potion potion)
    {
        if (!potion.isOnCooldown && potion.potionAction != null)
        {
            // 포션 사용 후 쿨 대기
            potion.potionAction.Use(potion.ItemSO);
            Inventory.instance.potionEquipSlots[potion.indexNum].transform.GetChild(0).GetComponent<DraggableUI>().itemCount--;
            Inventory.instance.potionEquipSlots[potion.indexNum].transform.GetChild(0).GetComponent<DraggableUI>().UpdateText();
            potionObject[potion.indexNum].GetComponent<DraggableUI>().itemCount--;
            potionObject[potion.indexNum].GetComponent<DraggableUI>().UpdateText();
            StartCoroutine(PotionCooldown(potion));
        }
        else
        {
            Debug.Log("스킬 재사용 대기 중");
        }
    }

    // 포션 쿨 대기 시간 처리
    IEnumerator PotionCooldown(Potion potion)
    {
        potion.isOnCooldown = true;

        Color originalColor = potion.potionImage.color;
        Color targetColor = new Color(0.3f, 0.3f, 0.3f, 1f);  // 포션 이미지 어둡게 변경

        potion.cooldownTimer = potion.cooldownTime;  // 재사용 대기시간 초기화

        while (potion.cooldownTimer > 0f)
        {
            potion.cooldownTimer -= Time.deltaTime;

            float colorInterpolation = 1 - (potion.cooldownTimer / potion.cooldownTime);
            potion.potionImage.color = Color.Lerp(targetColor, originalColor, colorInterpolation);

            UpdateCooldownUI(potion);
            yield return null;
        }

        // 포션 쿨이 끝나면 초기화
        potion.isOnCooldown = false;
        // 포션 이미지 기존으로 변경
        potion.potionImage.color = Color.white;

        yield return null;
    }

    // 포션 쿨 중ㅇ UI 업데이트
    void UpdateCooldownUI(Potion potion)
    {
        if (potion.potionImage == null)
        {
            return;
        }

        float cooldownPercentage = Mathf.Clamp01(1 - (potion.cooldownTimer / Mathf.Max(potion.cooldownTime, 0.01f)));
        // 포션 이미지에 재사용 대기 시간 표시
        potion.potionImage.fillAmount = cooldownPercentage;

        // 포션이 쿨타임 일 때만 텍스트 표시
        if (potion.isOnCooldown)
        {
            if (potion.cooldownTimer > 0f)
            {
                // 남은 재사용 시간을 텍스트로 표시
                //potion.cooldownText.text = Mathf.CeilToInt(potion.cooldownTimer).ToString();
            }
            else
            {
                //potion.cooldownText.text = null;  // 텍스트 숨기기
                // Debug.Log("재사용 가능");
            }
        }
    }
}
