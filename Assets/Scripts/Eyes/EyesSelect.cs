using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EyesSelect : MonoBehaviour
{
    public EyesDatabase db;
    public SpriteRenderer SkinsUsed;
    private int selectedOption = 0;
    public static int selectedeyeValue;

    //swipe
    Vector2 startTouchPos;
    Vector2 currentTouchPos;
    Vector2 endTouchPos;
    bool stopTouch = false;
    public float swipeRange;
    public float tapRange;

    private void Start()
    {
        foreach (Eyes e in db.eye)
        {
                e.value = Random.Range(2, 8);
        }
        updateeye(0);
    }
    private void updateeye(int selectedOption)
    {
        this.selectedOption = selectedOption;
        Eyes eyes = db.GetEye(selectedOption);
        SkinsUsed.sprite = eyes.EyesLook;

    }
    public void Swipe()
    {
        if (SelectButton.EyeTurn)
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
                        updateeye(selectedOption);
                        stopTouch = true;
                    }
                    else if (Distance.x > swipeRange)
                    {
                        if (selectedOption == db.eye.Length - 1)
                            return;
                        else
                            selectedOption++;
                        updateeye(selectedOption);
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

    public void OnLockEye()
    {
        Eyes eyes = db.GetEye(selectedOption);
        selectedeyeValue = eyes.value;
        Debug.Log("this is the score " + selectedeyeValue);
    }

}
