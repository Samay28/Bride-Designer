using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EyebrowSelect : MonoBehaviour
{
    public EyebrowsDatabase db;
    public SpriteRenderer SkinsUsed;
    private int selectedOption = 0;
    public static int selectedeyebrowValue;

    //swipe
    Vector2 startTouchPos;
    Vector2 currentTouchPos;
    Vector2 endTouchPos;
    bool stopTouch = false;
    public float swipeRange;
    public float tapRange;

    private void Start()
    {
        foreach (Eyebrows e in db.eyebrows)
        {
                if(e.Nothing)
                e.value = Random.Range(1,3);
                else
                e.value = Random.Range(4,8);
        }
        updateyebrows(0);
    }
    private void updateyebrows(int selectedOption)
    {
        Eyebrows eyebrows = db.GetEyebrows(selectedOption);
        SkinsUsed.sprite = eyebrows.EyebrowLook;

    }
    public void Swipe()
    {
            if(!PauseManager.IsPaused)
        if (SelectButton.EyebrowsTurn)
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
                        updateyebrows(selectedOption);
                        stopTouch = true;
                    }
                    else if (Distance.x > swipeRange)
                    {
                        if (selectedOption == db.eyebrows.Length - 1)
                            return;
                        else
                            selectedOption++;
                        updateyebrows(selectedOption);
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

    public void OnLockEyebrows()
    {
        Eyebrows eyebrows = db.GetEyebrows(selectedOption);
        selectedeyebrowValue = eyebrows.value;

        Debug.Log("this is the eyebrow score " + selectedeyebrowValue);

    }

}
