using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public TextMeshProUGUI highscore;
    public TextMeshProUGUI Rejections;
    public TextMeshProUGUI Success;
    public GameObject MainPanel;
    public GameObject SettingsPanel;
    int count = 0;
    void Start()
    {   
        count = PlayerPrefs.GetInt("Count", 0);
        PauseManager.IsPaused = false;
        if (PlayerPrefs.HasKey("highscore"))
        {
            GameManager.instance.highscore = PlayerPrefs.GetFloat("highscore");
            highscore.text = "Highscore: " + GameManager.instance.highscore.ToString("F2");
        }
        else
        {
            highscore.text = "Highscore: " + 0;
        }

        if (PlayerPrefs.HasKey("WeddingsDone"))
        {
            GameManager.instance.WeddingsDone = PlayerPrefs.GetInt("WeddingsDone");
            Success.text = "Success: " + GameManager.instance.WeddingsDone.ToString();
        }
        else
        {
            Success.text = "Success: " + 0;
        }

        if (PlayerPrefs.HasKey("WeddingsRuined"))
        {
            GameManager.instance.WeddingsRuined = PlayerPrefs.GetInt("WeddingsRuined");
            Rejections.text = "Rejections: " + GameManager.instance.WeddingsRuined.ToString();
        }
        else
        {
            Rejections.text = "Rejections: " + 0;
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void StartGame()
    {
        if (FirsTimeLoaded())
        {
            SceneManager.LoadScene(4);
        }
        else
        {
            SceneManager.LoadScene(1);
        }
    }
    public void Exit()
    {
        Application.Quit();
    }
    public void OpenSettings()
    {
        PauseManager.IsPaused = true;
        SettingsPanel.SetActive(true);
        MainPanel.SetActive(false);
    }
    public void BackMain()
    {
        PauseManager.IsPaused = false;
        SettingsPanel.SetActive(false);
        MainPanel.SetActive(true);
    }
    public bool FirsTimeLoaded()
{
        count = PlayerPrefs.GetInt("Count");
        if (count == 0)
        {
            count++;
            PlayerPrefs.SetInt("Count", count);
            return true;
        }
        else
        {   
            Debug.Log("fail2");
            return false;
        }
    }
}


