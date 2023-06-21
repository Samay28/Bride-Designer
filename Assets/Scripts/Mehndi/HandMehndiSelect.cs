using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HandMehndiSelect : MonoBehaviour
{
    public HandMehndiDatabase db;
    public SpriteRenderer SkinsUsed;
    private int selectedOption = 0;
    public static int selectedHMehndiValue;

    //swipe
    Vector2 startTouchPos;
    Vector2 currentTouchPos;
    Vector2 endTouchPos;
    bool stopTouch = false;
    public float swipeRange;
    public float tapRange;

    private void Start()
    {
        foreach (HandMehndi h in db.handMehndis)
        {

            if (!h.Nothing)
                h.value = Random.Range(4, 10);
            else
                h.value = Random.Range(1, 3);
        }
        updateHMehndi(0);
    }
    private void updateHMehndi(int selectedOption)
    {
        this.selectedOption = selectedOption;
        HandMehndi handmehndi = db.GetHandMehndi(selectedOption);
        SkinsUsed.sprite = handmehndi.HandMehndiLook;

    }
    public void Swipe()
    {   
            if(!PauseManager.IsPaused)
        if (SelectButton.HMehndiTurn)
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
                        updateHMehndi(selectedOption);
                        stopTouch = true;
                    }
                    else if (Distance.x > swipeRange)
                    {
                        if (selectedOption == db.handMehndis.Length - 1)
                            return;
                        else
                            selectedOption++;
                        updateHMehndi(selectedOption);
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
        HandMehndi handMehndi = db.GetHandMehndi(selectedOption);
        selectedHMehndiValue = handMehndi.value;
        Debug.Log("this is the hand mehndi score " + selectedHMehndiValue);
    }

}
