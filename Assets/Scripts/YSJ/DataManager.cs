using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class PlayerData
{   // �����Ϸ��� �������� ����.
    public string name;
    public int stage;
    public int gold;
    public int item;
}
public class DataManager : MonoBehaviour
{
    public static DataManager instance;

    PlayerData nowPlayer = new PlayerData();

    public string path;    // ���� ���� ���.
    public int nowSlot;   // ���� ���� ��ȣ.

    private void Awake()
    {
        instance = this;

        path = Application.persistentDataPath + "/save";    // �������� ��� ����.
    }

    public void SaveData()  // ������ ���� �Լ�.
    {
        string data = JsonUtility.ToJson(nowPlayer);
        File.WriteAllText(path + nowSlot.ToString(), data);
    }

    public void LoadData()  // ������ �ҷ����� �Լ�.
    {
        string data = File.ReadAllText(path + nowSlot.ToString());
        nowPlayer = JsonUtility.FromJson<PlayerData>(data);
    }

    public void DataClear()
    {
        nowSlot = -1;
        nowPlayer = new PlayerData();
    }
}
