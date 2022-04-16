using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

[Serializable]
public class SaveData
{
    [Header("Player Stats")]
    public float hp;
    public float damage;
    public float moveSpeed;

    [Header("Enemies Stats")]
    public float[] enemiesHp = new float[6];
    public float[] enemiesDamage = new float[6];

    [Header("NPC Stats")]
    [Range(0f, 100f)]
    public float whiteSpherePersent;
    [Range(0f, 100f)]
    public float redSpherePersent;
}

public class JsonLoader : Singleton<JsonLoader>
{
    public SaveData saveData;
    public SaveData get;

    public string GetPath(string fileName) => $@"C:\Users\user\Desktop\101_À±¼öÇö\JsonData\{fileName}.json";
    public void Write<T>(string fileName, T obj, bool overWrite = false)
    {
        string path = GetPath(fileName);
        if(!File.Exists(path) || overWrite)
        {
            File.WriteAllText(path, JsonUtility.ToJson(obj));
        }
    }

    public T Read<T>(string fileName)
    {
        return JsonUtility.FromJson<T>(File.ReadAllText(GetPath(fileName)));
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            Write("IngameData", saveData, true);
        if (Input.GetKeyDown(KeyCode.Alpha2))
            Read<SaveData>("IngameData");
    }
}
