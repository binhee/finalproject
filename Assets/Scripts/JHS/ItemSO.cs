using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ItemSO : ScriptableObject
{
    public int itemIDNum;
    public ItemType itemType;

    public int shieldTime;
    public int speedTime;
    public int speedPower;
    public int jumpTime;
    public int jumpPower;
    public int enchantTime;
    public int enchantPower;
}
