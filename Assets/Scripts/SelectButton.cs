using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;
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
<<<<<<< HEAD
    public static bool LMehndiTurn = false;
    public static bool HMehndiTurn = false;
    public GameObject DesignPanel;
    public GameObject DesignSelect;
    public GameObject MakeupPanel;
    public GameObject MehndiPanel;
    public GameObject MehndiSelect;
=======
    public GameObject DesignPanel;
    public GameObject MakeupPanel;
>>>>>>> 61fc34ef0dce2453d57397c91e1dead912e45055
    public GameObject Subdiv;
    public PlayableDirector Anim1;

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
<<<<<<< HEAD
        JewelTurn = false;
=======
>>>>>>> 61fc34ef0dce2453d57397c91e1dead912e45055
    }
    public void OutfitButton()
    {
        OutfitTurn = true;
        Hairturn = false;
        Subdiv.SetActive(true);
<<<<<<< HEAD
        JewelTurn = false;
=======

>>>>>>> 61fc34ef0dce2453d57397c91e1dead912e45055
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
        Subdiv.SetActive(false);
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
        Anim1.Play();
    }
    public void NewLevel()
    {
        SceneManager.LoadScene("GameScene2");
    }
<<<<<<< HEAD
    public void LastLevel()
    {
        SceneManager.LoadScene("GameScene3");
    }

     public void NextButtonMehndi()
    {
        MehndiPanel.SetActive(true);
        DesignPanel.SetActive(false);
        OutfitTurn = false;
        Hairturn = false;
        HMehndiTurn = true;
        JewelTurn = false;
        DesignSelect.SetActive(false);
        MehndiSelect.SetActive(true);
    }
    public void MehndiPanelOver()
    {
        MehndiPanel.SetActive(false);
        MakeupPanel.SetActive(true);
        HMehndiTurn = false;
        LMehndiTurn = false;
        EyeTurn = true;
        DesignSelect.SetActive(true);
        MehndiSelect.SetActive(false);
    }
    public void HandsTurn()
    {
        HMehndiTurn = true;
        LMehndiTurn = false;
    }
    public void LegsTurn()
    {
        HMehndiTurn = false;
        LMehndiTurn = true;
    }
    
=======

>>>>>>> 61fc34ef0dce2453d57397c91e1dead912e45055
}
