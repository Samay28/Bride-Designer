using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectButton : MonoBehaviour
{
    public static bool Hairturn = true;
    public static bool OutfitTurn = false;   
    public GameObject DesignPanel;
    public GameObject MakeupPanel;

    void Awake()
    {
       Hairturn = true;
       OutfitTurn = false;
       DesignPanel.SetActive(true);
       MakeupPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void HairButton()
    {
        Hairturn = true;
        OutfitTurn = false;
    }
    public void OutfitButton()
    {
        OutfitTurn = true;
        Hairturn = false;
    }
    public void NextButton()
    {
        MakeupPanel.SetActive(true);
        DesignPanel.SetActive(false);
        OutfitTurn = false;
        Hairturn = false;
    }

}
