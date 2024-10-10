using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;

public class DataStorage : MonoBehaviour
{
    public static DataStorage Instance { get; private set; }
    public string userName { get; private set; } = "NoName";
    public string highScoreUserName { get; private set; }  = "NoName";
    public int highScore { get; private set; } = 0;

    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    public void ChangeUserName(TMP_InputField input)
    {
        userName = input.text;
    }

    [Serializable]
    class SaveData
    {
        public string highScoreUserName;
        public int highScore;
    }

    public void SaveHighScore(int newHighScore)
    {
        highScoreUserName = userName;
        highScore = newHighScore;
        SaveData data = new SaveData();
        data.highScoreUserName = highScoreUserName;
        data.highScore = highScore;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }
    public void LoadHighScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            highScore = data.highScore;
            highScoreUserName = data.highScoreUserName;
        }
    }
}
