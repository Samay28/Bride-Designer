using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class JewelSelect : MonoBehaviour
{
    public JewelleryDatabase db;
    public SpriteRenderer SkinsUsed;
    private int selectedOption = 0;
    public static int selectedJewelValue;

    //swipe
    Vector2 startTouchPos;
    Vector2 currentTouchPos;
    Vector2 endTouchPos;
    bool stopTouch = false;
    public float swipeRange;
    public float tapRange;

    private void Start()
    {
        foreach (Jewellery j in db.Jewelleries)
        {
            if (GameManager.IsLevel1)
                if (j.Nothing)
                    j.value = Random.Range(7, 9);
                else
                    j.value = Random.Range(3, 6);
            else if(GameManager.IsLevel2)
            {
                j.value = Random.Range(4,8);
            }
        }
        updateJewel(0);
    }
    private void updateJewel(int selectedOption)
    {
        this.selectedOption = selectedOption;
        Jewellery jewellery = db.GetJewellery(selectedOption);
        SkinsUsed.sprite = jewellery.JewelleryLook;

    }
    public void Swipe()
    {
        if (SelectButton.JewelTurn)
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
                        updateJewel(selectedOption);
                        stopTouch = true;
                    }
                    else if (Distance.x > swipeRange)
                    {
                        if (selectedOption == db.Jewelleries.Length - 1)
                            return;
                        else
                            selectedOption++;
                        updateJewel(selectedOption);
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

    public void OnLockJewel()
    {
        Jewellery jewellery = db.GetJewellery(selectedOption);
        selectedJewelValue = jewellery.value;
        Debug.Log("this is the score " + selectedJewelValue);
    }

}
