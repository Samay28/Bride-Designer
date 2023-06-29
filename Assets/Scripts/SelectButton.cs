using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;
public class SelectButton : MonoBehaviour
{
    public static bool Hairturn = false;
    public static bool OutfitTurn = false;
    public static bool JewelTurn = false;
    public static bool EyeTurn = false;
    public static bool EyebrowsTurn = false;
    public static bool EyelashesTurn = false;
    public static bool cheeksturn = false;
    public static bool LipsTurn = false;

    public static bool LMehndiTurn = false;
    public static bool HMehndiTurn = false;
    public static bool ZoomNow;
    public GameObject DesignPanel;
    public GameObject DesignSelect;
    public GameObject MakeupPanel;
    public GameObject MehndiPanel;
    public GameObject MehndiSelect;

    public GameObject Subdiv;
    public PlayableDirector Anim1;
    public GameObject PauseButton;

    void Awake()
    {
        Hairturn = false;
        OutfitTurn = false;
        DesignPanel.SetActive(true);
        MakeupPanel.SetActive(false);
        Subdiv.SetActive(true);
    }
    void Start()
    {
        ZoomNow = false;
        PauseButton.SetActive(true);
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
        JewelTurn = false;
        PlayerController.instance.SetPos1();
    }
    public void OutfitButton()
    {
        OutfitTurn = true;
        Hairturn = false;
        Subdiv.SetActive(true);
        JewelTurn = false;
        PlayerController.instance.SetInPos();
    }
    public void JewelButton()
    {
        OutfitTurn = false;
        Hairturn = false;
        JewelTurn = true;
        Subdiv.SetActive(false);
        PlayerController.instance.SetPos1();
    }

    public void NextButton()
    {
        MakeupPanel.SetActive(true);
        DesignPanel.SetActive(false);
        OutfitTurn = false;
        Hairturn = false;
        JewelTurn = false;
        PlayerController.instance.SetPos();
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
        PlayerController.instance.SetInPos();
        PauseButton.SetActive(false);
    }
    public void NewLevel()
    {
        SceneManager.LoadScene("GameScene2");
    }

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
        JewelTurn = false;
        DesignSelect.SetActive(false);
        MehndiSelect.SetActive(true);
        PlayerController.instance.SetInPos();
    }
    public void MehndiPanelOver()
    {
        MehndiPanel.SetActive(false);
        MakeupPanel.SetActive(true);
        HMehndiTurn = false;
        LMehndiTurn = false;
        DesignSelect.SetActive(true);
        MehndiSelect.SetActive(false);
        PlayerController.instance.SetPos();
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


}
