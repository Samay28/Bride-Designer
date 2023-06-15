using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public static bool IsLevel1;
    float Score;
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
    }
}
