using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField]
    public static bool IsLevel1;
    public static bool IsLevel2;
    public static bool IsLevel3;
    public bool levelCleared1;
    public static float Score;
    public static float Score2;
    public static float Score3;
    public float MasterScore;
    public float highscore;
    public int WeddingsDone = 0;
    public int WeddingsRuined = 0;
    public Image[] stars;
    public int WhichStarHalf;
    public float fillAmount;
    public TextMeshProUGUI ResultTxt;
    public GameObject ButtonNewLevel;
    public GameObject ButtonNewLevel2;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        IsLevel1 = true;
       
    }
    private void Start()
    {
        MasterScore = 0;
        Debug.Log("highscore " + highscore);
        Scene currentScene = SceneManager.GetActiveScene();
        if (currentScene.name == "GameScene2")
        {
            IsLevel2 = true;
            IsLevel1 = false;
            Debug.Log("level2");
        }
        if (currentScene.name == "GameScene1")
        {
            IsLevel1 = true;
            IsLevel2 = false;
            IsLevel3 = false;
            Debug.Log("level1");
        }
        else if (currentScene.name == "GameScene3")
        {
            IsLevel1 = false;
            IsLevel2 = false;
            IsLevel3 = true;
            Debug.Log("level3");
        }
        highscore = PlayerPrefs.GetFloat("highscore", 0);
        WeddingsDone = PlayerPrefs.GetInt("WeddingsDone", 0);
        WeddingsRuined = PlayerPrefs.GetInt("WeddingsRuined ", 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (levelCleared1)
        {
            if (ButtonNewLevel != null)
                ButtonNewLevel.SetActive(true);
            else
            if (ButtonNewLevel != null)
                ButtonNewLevel.SetActive(false);
        }

        if (PlayerPrefs.HasKey("highscore"))
        {
            highscore = PlayerPrefs.GetFloat("highscore");
        }
        if (PlayerPrefs.HasKey("WeddingsDone"))
        {
            WeddingsDone = PlayerPrefs.GetInt("WeddingsDone");

        }
        if (PlayerPrefs.HasKey("WeddingsRuined"))
        {
            WeddingsRuined = PlayerPrefs.GetInt("WeddingsRuined");

        }



        UpdateHighscore();


    }
    public void CalculateScoreLevel1()
    {
        Score = (CheeksSelect.selectedcheeksValue + EyebrowSelect.selectedeyebrowValue + EyelasheSelect.selectedeyelashValue + EyesSelect.selectedeyeValue + HairstyleSelect.selectedhairValue + JewelSelect.selectedJewelValue + OutfitSelect.selectedOutfitValue + LipsSelect.selectedlipsValue) / 8f;
        Debug.Log("aVG Score : " + Score);
        Score = Score / 2;
        Debug.Log("Total Score : " + Score);
        BeginResult();

    }
    public void CalculateScoreLevel2()
    {
        Score2 = (CheeksSelect.selectedcheeksValue + EyebrowSelect.selectedeyebrowValue + EyelasheSelect.selectedeyelashValue + EyesSelect.selectedeyeValue + HairstyleSelect.selectedhairValue + JewelSelect.selectedJewelValue + OutfitSelect.selectedOutfitValue + LipsSelect.selectedlipsValue) / 8f;
        Debug.Log("aVG Score : " + Score2);
        Score2 = Score2 / 2;
        Debug.Log("Total Score : " + Score2);
        BeginResult();
    }
    public void CalculateScoreLevel3()
    {
        Score3 = (CheeksSelect.selectedcheeksValue + EyebrowSelect.selectedeyebrowValue + EyelasheSelect.selectedeyelashValue + EyesSelect.selectedeyeValue + HairstyleSelect.selectedhairValue + JewelSelect.selectedJewelValue + OutfitSelect.selectedOutfitValue + LipsSelect.selectedlipsValue + HandMehndiSelect.selectedHMehndiValue + LegMehndiSelect.selectedLMehndiValue) / 10f;
        Debug.Log("aVG Score : " + Score3);
        Score3 = Score3 / 2;
        MasterScore = Score + Score + Score3;
        Debug.Log("Total Score : " + MasterScore);
        MasterScore = MasterScore / 3;
        Debug.Log("Total Score : " + MasterScore);
        BeginResult();
    }
    public void UpdateHighscore()
    {
        if (MasterScore > highscore)
        {
            highscore = MasterScore;
            Debug.Log("Beat");
            PlayerPrefs.SetFloat("highscore", highscore);
            PlayerPrefs.Save();
        }
    }

    public void BeginResult()
    {
        if (IsLevel1)
        {
            WhichStarHalf = Mathf.FloorToInt(Score);
            fillAmount = Score - WhichStarHalf;
            stars[WhichStarHalf].fillAmount = fillAmount;
        }
        else if (IsLevel2)
        {
            WhichStarHalf = Mathf.FloorToInt(Score2);
            fillAmount = Score2 - WhichStarHalf;
            stars[WhichStarHalf].fillAmount = fillAmount;
        }
        else if (IsLevel3)
        {
            WhichStarHalf = Mathf.FloorToInt(MasterScore);
            fillAmount = MasterScore - WhichStarHalf;
            stars[WhichStarHalf].fillAmount = fillAmount;
        }

        for (int i = WhichStarHalf + 1; i < stars.Length; i++)
        {
            stars[i].gameObject.SetActive(false);
        }
        if (IsLevel1)
            if (Score >= 2)
            {
                ResultTxt.text = "Level Cleared";
                ResultTxt.color = Color.green;
                levelCleared1 = true;

            }
            else
            {
                ResultTxt.text = "Wedding Cancelled";
                ResultTxt.color = Color.red;
                levelCleared1 = false;
                WeddingsRuined++;
                PlayerPrefs.SetInt("WeddingsRuined", WeddingsRuined);
                Debug.Log("WeddingsRuined " + WeddingsRuined);
            }
        else if (IsLevel2)
            if (Score2 >= 2.37)
            {
                ResultTxt.text = "Level Cleared";
                ResultTxt.color = Color.green;
                ButtonNewLevel2.SetActive(true);

            }
            else
            {
                ResultTxt.text = "Wedding Cancelled";
                ResultTxt.color = Color.red;
                WeddingsRuined++;
                PlayerPrefs.SetInt("WeddingsRuined", WeddingsRuined);
                Debug.Log("WeddingsRuined " + WeddingsRuined);
                ButtonNewLevel2.SetActive(false);
            }
        else if (IsLevel3)
            if (MasterScore >= 2.6)
            {
                ResultTxt.text = "Wedding Successful!";
                ResultTxt.color = Color.green;
                WeddingsDone++;
                PlayerPrefs.SetInt("WeddingsDone", WeddingsDone);
                Debug.Log("WeddingsDone " + WeddingsDone);
            }
            else
            {
                ResultTxt.text = "Wedding Cancelled";
                ResultTxt.color = Color.red;
                WeddingsRuined++;
                PlayerPrefs.SetInt("WeddingsRuined", WeddingsRuined);
                Debug.Log("WeddingsRuined " + WeddingsRuined);
            }
    }
    public void ReturnMenu()
    {
        SceneManager.LoadScene(0);
    }

}
