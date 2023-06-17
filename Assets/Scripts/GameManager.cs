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
    float Score;
    float Score2;
    float Score3;
    public float MasterScore;
    public Image[] stars;
    public int WhichStarHalf;
    public float fillAmount;
    public TextMeshProUGUI ResultTxt;
    public GameObject ButtonNewLevel;
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
        Scene currentScene = SceneManager.GetActiveScene();
        if(currentScene.name == "GameScene2")
        {
            IsLevel2 = true;
            IsLevel1 = false;
            Debug.Log("level2");
        }
        if(currentScene.name == "GameScene1")
        {
            IsLevel1 = true;
            IsLevel2 = false;
            IsLevel3 = false;
            Debug.Log("level1");
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (levelCleared1)
            if (ButtonNewLevel != null)
                ButtonNewLevel.SetActive(true);
            else
            if (ButtonNewLevel != null)
                ButtonNewLevel.SetActive(false);
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
    public void BeginResult()
    {
        WhichStarHalf = Mathf.FloorToInt(Score);
        fillAmount = Score - WhichStarHalf;
        stars[WhichStarHalf].fillAmount = fillAmount;

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
            }
        else if (IsLevel2)
            if (Score2 >= 2.5)
            {
                ResultTxt.text = "Level Cleared";
                ResultTxt.color = Color.green;
            }
            else
            {
                ResultTxt.text = "Wedding Cancelled";
                ResultTxt.color = Color.red;
            }
        else if (IsLevel3)
            if (Score3 >= 3)
            {
                ResultTxt.text = "Level Cleared";
                ResultTxt.color = Color.green;
            }
            else
            {
                ResultTxt.text = "Wedding Cancelled";
                ResultTxt.color = Color.red;
            }
    }
}
