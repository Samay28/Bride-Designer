using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public static bool IsLevel1;
    float Score;
    public Image[] stars;
    public int WhichStarHalf;
    public float fillAmount;
    public TextMeshProUGUI ResultTxt;
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
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void CalculateScoreLevel1()
    {
        Score = (CheeksSelect.selectedcheeksValue + EyebrowSelect.selectedeyebrowValue + EyelasheSelect.selectedeyelashValue + EyesSelect.selectedeyeValue + HairstyleSelect.selectedhairValue + JewelSelect.selectedJewelValue + OutfitSelect.selectedOutfitValue + LipsSelect.selectedlipsValue)/8f;
        Debug.Log("aVG Score : " + Score);
        Score = Score/2;
        Debug.Log("Total Score : " + Score);
        BeginResult();
        
    }
    public void BeginResult()
    {
        WhichStarHalf = Mathf.FloorToInt(Score);
        fillAmount = Score - WhichStarHalf;
        stars[WhichStarHalf].fillAmount = fillAmount;

        for(int i = WhichStarHalf+1; i<stars.Length; i++)
        {
            stars[i].gameObject.SetActive(false);
        }

        if(Score>=2.5)
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
