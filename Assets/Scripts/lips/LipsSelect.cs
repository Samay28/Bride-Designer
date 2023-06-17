using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LipsSelect : MonoBehaviour
{
    public LipsDatabase db;
    public SpriteRenderer SkinsUsed;
    private int selectedOption = 0;
    public static int selectedlipsValue;

    //swipe
    Vector2 startTouchPos;
    Vector2 currentTouchPos;
    Vector2 endTouchPos;
    bool stopTouch = false;
    public float swipeRange;
    public float tapRange;

    private void Start()
    {
        foreach (Lips l in db.lips)
        {
            if (GameManager.IsLevel1)
            if(l.Nothing)
                l.value = Random.Range(7, 10);
            else 
                l.value = Random.Range(4, 7);
            else if(GameManager.IsLevel2)
            {
                l.value = Random.Range(5,10);
            }
        }
        updatelips(0);
    }
    private void updatelips(int selectedOption)
    {
        this.selectedOption = selectedOption;
        Lips lips = db.GetLips(selectedOption);
        SkinsUsed.sprite = lips.LipsLook;

    }
    public void Swipe()
    {
        if (SelectButton.LipsTurn)
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
                        updatelips(selectedOption);
                        stopTouch = true;
                    }
                    else if (Distance.x > swipeRange)
                    {
                        if (selectedOption == db.lips.Length - 1)
                            return;
                        else
                            selectedOption++;
                        updatelips(selectedOption);
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
        Lips lips = db.GetLips(selectedOption);
        selectedlipsValue = lips.value;
        Debug.Log("this is the score " + selectedlipsValue);
    }

}
