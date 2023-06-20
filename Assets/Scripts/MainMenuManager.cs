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
    void Start()
    {
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
        SceneManager.LoadScene(1);
    }
    public void Exit()
    {
        Application.Quit();
    }
}
