using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SortButton : MonoBehaviour
{
  public void SortLast(GameObject panel)
    {
        panel.GetComponent<Transform>().SetAsLastSibling();
    }
}
