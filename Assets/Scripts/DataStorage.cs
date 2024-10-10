using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DataStorage : MonoBehaviour
{
    public static DataStorage Instance { get; private set; }
    public string userName { get; private set; }

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
}
