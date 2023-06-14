using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CheeksSelect : MonoBehaviour
{
    public CheeksDatabase db;
    public SpriteRenderer SkinsUsed;
    private int selectedOption = 0;
    public static int selectedcheeksValue;

    //swipe
    Vector2 startTouchPos;
    Vector2 currentTouchPos;
    Vector2 endTouchPos;
    bool stopTouch = false;
    public float swipeRange;
    public float tapRange;

    private void Start()
    {
        foreach (Cheeks c in db.cheeks)
        {
            if (GameManager.IsLevel1)
                c.value = Random.Range(5, 10);
        }
        updatecheeks(0);
    }
    private void updatecheeks(int selectedOption)
    {
        Cheeks cheeks = db.GetCheeks(selectedOption);
        SkinsUsed.sprite = cheeks.CheeksLook;

    }
    public void Swipe()
    {
        if (SelectButton.cheeksturn)
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
                        updatecheeks(selectedOption);
                        stopTouch = true;
                    }
                    else if (Distance.x > swipeRange)
                    {
                        if (selectedOption == db.cheeks.Length - 1)
                            return;
                        else
                            selectedOption++;
                        updatecheeks(selectedOption);
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
        Cheeks cheeks = db.GetCheeks(selectedOption);
        selectedcheeksValue = cheeks.value;
        Debug.Log("this is the score " + selectedcheeksValue);
    }

}
