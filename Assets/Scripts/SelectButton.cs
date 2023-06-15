using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectButton : MonoBehaviour
{
    public static bool Hairturn = true;
    public static bool OutfitTurn = false;
    public static bool JewelTurn = false;
    public static bool EyeTurn = false;
    public static bool EyebrowsTurn = false;
    public static bool EyelashesTurn = false;
    public static bool cheeksturn = false;
    public static bool LipsTurn = false;
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
        EyeTurn = true;
        JewelTurn = false;
    }
    public void JewelButton()
    {
        OutfitTurn = false;
        Hairturn = false;
        JewelTurn = true;
    }
     public void EyeButton()
    {
        EyeTurn = true;
        EyelashesTurn = false;
        EyebrowsTurn = false;
        LipsTurn = false;
        cheeksturn = false;
    }
    public void LipsButton()
    {
        EyeTurn = false;
        EyelashesTurn = false;
        EyebrowsTurn = false;
        LipsTurn = true;
        cheeksturn = false;
    }
      public void CheeksButton()
    {
        EyeTurn = false;
        EyelashesTurn = false;
        EyebrowsTurn = false;
        LipsTurn = false;
        cheeksturn = true;
    }
     public void EyebrowsButton()
    {
        EyeTurn = false;
        EyelashesTurn = false;
        EyebrowsTurn = true;
        LipsTurn = false;
        cheeksturn = false;
    }
     public void EyelashesButton()
    {
        EyeTurn = false;
        EyelashesTurn = true;
        EyebrowsTurn = false;
        LipsTurn = false;
        cheeksturn = false;
    }
    public void LockButton()
    {
        EyeTurn = false;
        EyelashesTurn = false;
        EyebrowsTurn = false;
        LipsTurn = false;
        cheeksturn = false;
        MakeupPanel.SetActive(false);
    }

}
