using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    // Start is called before the first frame update
    public void InventoryLoad()     // �κ��丮 �ε� �Լ�
    {
        SceneManager.LoadScene("JHS_Item");     // "" �κ��丮 Scene �߰�
    }

    public void StoreLoad()     // ���� �ε� �Լ�
    {
        SceneManager.LoadScene("JHS_Item");     // "" ���� Scene �߰�
    }
}
