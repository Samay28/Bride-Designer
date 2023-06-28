using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HairstyleSelect : MonoBehaviour
{
    public HairstyleDatabase db;
    public SpriteRenderer SkinsUsed;
    private int selectedOption = 0;

   public static int selectedhairValue;
    Vector2 startTouchPos;
    Vector2 currentTouchPos;
    Vector2 endTouchPos;
    bool stopTouch = false;
    public float swipeRange;
    public float tapRange;
    private void Start()
    {   
        foreach(Hairstyle h in db.Hairstyles)
        {
            h.value = Random.Range(3,10);

        }
        updateHairstyle(0);
    }

    private void updateHairstyle(int selectedOption)
    {   
        this.selectedOption = selectedOption;
        Hairstyle hairstyle = db.GetHairstyle(selectedOption);
        SkinsUsed.sprite = hairstyle.HairstyleLook;
    }
    public void Swipe()
    {   
        if(!PauseManager.IsPaused)
        if (SelectButton.Hairturn)
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
                            selectedOption = 10;
                        else
                            selectedOption--;
                        updateHairstyle(selectedOption);
                        stopTouch = true;
                    }
                    else if (Distance.x > swipeRange)
                    {
                        if (selectedOption == 10)
                            selectedOption=0;
                        else
                            selectedOption++;
                        updateHairstyle(selectedOption);
                        stopTouch = true;
                    }
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
    private void Update()
    {
        Swipe();
    }
     public  void  OnLockHairstyle()
    {   
        Hairstyle hairstyle = db.GetHairstyle(selectedOption);
        selectedhairValue = hairstyle.value;

        Debug.Log("this is the hair score " + selectedhairValue);

    }
}
