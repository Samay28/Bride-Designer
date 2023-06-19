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
<<<<<<< HEAD
            h.value = Random.Range(3,10);
=======
            h.value = Random.Range(1,10);
>>>>>>> 61fc34ef0dce2453d57397c91e1dead912e45055
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
                            return;
                        else
                            selectedOption--;
                        updateHairstyle(selectedOption);
                        stopTouch = true;
                    }
                    else if (Distance.x > swipeRange)
                    {
                        if (selectedOption == 10)
                            return;
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
<<<<<<< HEAD
        Debug.Log("this is the hair score " + selectedhairValue);
=======
        Debug.Log("this is the score " + selectedhairValue);
>>>>>>> 61fc34ef0dce2453d57397c91e1dead912e45055
    }
}
