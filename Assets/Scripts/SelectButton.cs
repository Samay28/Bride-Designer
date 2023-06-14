using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectButton : MonoBehaviour
{
    public static bool Hairturn = true;
    public static bool OutfitTurn = false;
    public static bool JewelTurn = false;
    public GameObject DesignPanel;
    public GameObject MakeupPanel;
    public GameObject Subdiv;


    void Awake()
    {
        Hairturn = true;
        OutfitTurn = false;
        DesignPanel.SetActive(true);
        MakeupPanel.SetActive(false);
        Subdiv.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void HairButton()
    {
        Hairturn = true;
        OutfitTurn = false;
        Subdiv.SetActive(false);
    }
    public void OutfitButton()
    {
        OutfitTurn = true;
        Hairturn = false;
        Subdiv.SetActive(true);

    }
    public void NextButton()
    {
        MakeupPanel.SetActive(true);
        DesignPanel.SetActive(false);
        OutfitTurn = false;
        Hairturn = false;
    }
    public void JewelButton()
    {
        OutfitTurn = false;
        Hairturn = false;
        JewelTurn = true;

    }

}
