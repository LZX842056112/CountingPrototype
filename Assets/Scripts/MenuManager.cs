using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance;
    public string curName;
    public string bestName;
    public int bestScore;

    private void Awake()
    {
        // start of new code
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        // end of new code
        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadName();
    }

    [System.Serializable]
    class SaveData
    {
        public string bestName_t = "nobody";
        public string bestName
        {
            get { return bestName_t; } // getter returns backing field
            set 
            {
                if (!string.IsNullOrEmpty(value))
                {
                    bestName_t = value;
                }
                else
                {
                    Debug.LogError("You can't set a null Name!");
                }
            } // setter uses backing field
        }

        public int bestScore = 0;
    }
    public void SaveName(int m_Points)
    {
        SaveData saveData = new SaveData();
        saveData.bestName = curName;
        saveData.bestScore = m_Points;
        string json = JsonUtility.ToJson(saveData);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadName()
    {
        //print(Application.persistentDataPath);
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            bestName = data.bestName;
            bestScore = data.bestScore;
        }
    }
}
