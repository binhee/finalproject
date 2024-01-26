using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateSlots : MonoBehaviour
{
    public GameObject slot;
    private void Start()
    {
        CreateSlot();
    }
    public void CreateSlot()
    {
        for(int i = 0; i < 25; i++)
        {
            Inventory.instance.itemSlotList.Add(Instantiate(slot, gameObject.transform).GetComponent<Slot>());
        }
        Debug.Log("a");
        Inventory.instance.ExitInventoryPanel();
    }
}
