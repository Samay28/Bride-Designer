using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class OutfitSelect : MonoBehaviour
{
    public OutfitDatabase db;
    public SpriteRenderer SkinsUsed;
    private int selectedOption = 0;

    //swipe
    Vector2 startTouchPos;
    Vector2 currentTouchPos;
    Vector2 endTouchPos;
    bool stopTouch = false;
    public float swipeRange;
    public float tapRange;

    private void Start()
    {
        foreach (Outfit o in db.outfits)
        {   
            if(GameManager.IsLevel1)
            if (o.isTraditional)
            {
                o.value = Random.Range(1, 3);
                Debug.Log("Selected outfit value: " + o.value);
            }
            else if (o.isModern)
            {
                o.value = Random.Range(4, 6);
                Debug.Log("Selected outfit value: " + o.value);
            }
            else if (o.isCasual)
            {
                o.value = Random.Range(7, 10);
                Debug.Log("Selected outfit value: " + o.value);
            }
        }
        updateOutfit(0);
    }
    private void updateOutfit(int selectedOption)
    {
        Outfit outfit = db.GetOutfit(selectedOption);
        SkinsUsed.sprite = outfit.OutfitLook;
    }
    public void Swipe()
    {
        if (SelectButton.OutfitTurn)
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
                        updateOutfit(selectedOption);
                        stopTouch = true;
                    }
                    else if (Distance.x > swipeRange)
                    {
                        if (selectedOption == db.outfits.Length-1)
                            return;
                        else
                            selectedOption++;
                        updateOutfit(selectedOption);
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
    public void OnClickTradButton()
    {   
        selectedOption = 0;
        updateOutfit(selectedOption);
    }
     public void OnClickCasualButton()
    {   
        selectedOption = 10;
        updateOutfit(selectedOption);
    }
    public void OnClickModernButton()
    {   
        selectedOption = 20;
        updateOutfit(selectedOption);
    }
    

}
