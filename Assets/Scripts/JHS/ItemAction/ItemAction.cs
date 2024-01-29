using System.Collections;
using System.Collections.Generic;
using UnityEngine;

  abstract public class ItemAction : MonoBehaviour
{
    public abstract void Use(ItemSO itemNum);
    public abstract void Delete();
    public abstract void Upgrade();
    public abstract void Mix();
}
