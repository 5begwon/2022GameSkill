using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

[Serializable]
public class SaveData
{
    public string name;
    public int score;
}

public class JsonLoader : Singleton<JsonLoader>
{
    public SaveData saveData;
    public SaveData get;

    public string GetPath(string fileName) => $@"C:\Users\user\Desktop\JsonData\{fileName}.json";
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
            Write("ScoreRank", saveData, true);
        if (Input.GetKeyDown(KeyCode.Alpha2))
            Read<SaveData>("ScoreRank");
    }
}
