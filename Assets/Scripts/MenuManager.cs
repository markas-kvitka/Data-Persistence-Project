using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public void Start()
    {
        DataStorage.Instance.LoadHighScore();
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
}
