using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    public GameObject PausePanel;
    public GameObject SettingsPanel;
    public GameObject Fade;
    public static bool IsPaused;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnClickPause()
    {   
        IsPaused = true;
        PausePanel.SetActive(false);
        SettingsPanel.SetActive(true);
        Fade.SetActive(true);
    }
    public void OnClickBack()
    {   
        IsPaused = false;
        SettingsPanel.SetActive(false);
        PausePanel.SetActive(true);
        Fade.SetActive(false);
    }
}
