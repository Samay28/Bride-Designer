using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LegMehndiSelect : MonoBehaviour
{
    public LegMehndiDatabase db;
    public SpriteRenderer SkinsUsed;
    private int selectedOption = 0;
    public static int selectedLMehndiValue;

    //swipe
    Vector2 startTouchPos;
    Vector2 currentTouchPos;
    Vector2 endTouchPos;
    bool stopTouch = false;
    public float swipeRange;
    public float tapRange;

    private void Start()
    {
        foreach (LegMehndi l in db.LegMehndis)
        {

            if (!l.Nothing)
                l.value = Random.Range(4, 10);
            else
                l.value = Random.Range(1, 3);
        }
        updateLMehndi(0);
    }
    private void updateLMehndi(int selectedOption)
    {
        this.selectedOption = selectedOption;
        LegMehndi legMehndi = db.GetLegMehndi(selectedOption);
        SkinsUsed.sprite = legMehndi.LegMehndiLook;

    }
    public void Swipe()
    {
            if(!PauseManager.IsPaused)
        if (SelectButton.LMehndiTurn)
        {   
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
            {
                startTouchPos = Input.GetTouch(0).position;
            }
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                currentTouchPos = Input.GetTouch(0).position;
                Vector2 Distance = currentTouchPos - startTouchPos;

                if (!stopTouch)
                {
                    if (Distance.x < -swipeRange)
                    {
                        if (selectedOption == 0)
                            return;
                        else
                            selectedOption--;
                        updateLMehndi(selectedOption);
                        stopTouch = true;
                    }
                    else if (Distance.x > swipeRange)
                    {
                        if (selectedOption == db.LegMehndis.Length - 1)
                            selectedOption=0;
                        else
                            selectedOption++;
                        updateLMehndi(selectedOption);
                        stopTouch = true;
                    }
                }
            }
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                stopTouch = false;
                endTouchPos = Input.GetTouch(0).position;
                Vector2 Distance = endTouchPos - startTouchPos;
            }
        }
    }
    private void Update()
    {
        Swipe();

    }

    public void OnLocklips()
    {
        LegMehndi legMehndi = db.GetLegMehndi(selectedOption);
        selectedLMehndiValue = legMehndi.value;
        Debug.Log("this is the leg mehndi score " + selectedLMehndiValue);
    }

}
