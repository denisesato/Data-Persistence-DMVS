using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public string playerName;
    public string highScorePlayerName;
    public float highScore;
    private string persistenceFile = "/savefile.json";


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        LoadHighScore();
    }

    public void SetPlayerName(string name)
    {
        playerName = name; 
    }

    [System.Serializable]
    class SaveData
    {
        public string highScorePlayerName;
        public float highScore;
    }
    public void SaveHighScore()
    {
        SaveData data = new SaveData();
        data.highScore = highScore;
        data.highScorePlayerName = highScorePlayerName;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + persistenceFile, json);
    }

    public void LoadHighScore()
    {
        string path = Application.persistentDataPath + persistenceFile;
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            highScore = data.highScore;
            highScorePlayerName = data.highScorePlayerName;
        }
    }
    
}
