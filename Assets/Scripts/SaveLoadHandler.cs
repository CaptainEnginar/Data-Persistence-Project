using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class SaveLoadHandler : MonoBehaviour
{
    public static SaveLoadHandler Instance;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    [System.Serializable]
    public class SaveData
    {
        int id;
        public string name;
        public int point;
    }

    public void SaveName(string name)
    {
        SaveData data = new SaveData();
        data.name = name;
        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void SavePoint(string name, int point)
    {
        SaveData data = new SaveData();
        data.name = name;
        data.point = point;
        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public SaveData LoadData()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            return data;
        }
        else 
            return null;
    }
}
