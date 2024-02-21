using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class PlayerData
{   // 저장하려는 정보들의 변수.
    public string name;
    public int stage;
    public int gold;
    public int item;
}
public class DataManager : MonoBehaviour
{
    public static DataManager instance;

    PlayerData nowPlayer = new PlayerData();

    public string path;    // 저장 파일 경로.
    public int nowSlot;   // 현재 슬롯 번호.

    private void Awake()
    {
        instance = this;

        path = Application.persistentDataPath + "/save";    // 저장파일 경로 지정.
    }

    public void SaveData()  // 데이터 저장 함수.
    {
        string data = JsonUtility.ToJson(nowPlayer);
        File.WriteAllText(path + nowSlot.ToString(), data);
    }

    public void LoadData()  // 데이터 불러오기 함수.
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
