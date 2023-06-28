using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class OutfitSelect : MonoBehaviour
{
    public OutfitDatabase db;
    public SpriteRenderer SkinsUsed;
    private int selectedOption = 0;
    public static int selectedOutfitValue;
    Vector2 startTouchPos;
    Vector2 currentTouchPos;
    Vector2 endTouchPos;
    bool stopTouch = false;
    public float swipeRange;
    public float tapRange;
    public int lastIndex;
    public int FirstIndex;

    private void Start()
    {
        updateOutfit(0);
        UpdateValuesOutfit();
        lastIndex = db.outfits.Length;
        FirstIndex = 0;
    }
    private void updateOutfit(int selectedOption)
    {
        this.selectedOption = selectedOption;
        Outfit outfit = db.GetOutfit(selectedOption);
        SkinsUsed.sprite = outfit.OutfitLook;
    }
    public void Swipe()
    {
        if (!PauseManager.IsPaused)
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
                            if (selectedOption == FirstIndex)
                                selectedOption = lastIndex-1;
                            else
                                selectedOption--;
                            updateOutfit(selectedOption);
                            stopTouch = true;
                        }
                        else if (Distance.x > swipeRange)
                        {
                            if (selectedOption == lastIndex - 1)
                                selectedOption = FirstIndex;
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
        SelectButton.OutfitTurn = true;
        selectedOption = 0;
        updateOutfit(selectedOption);
        lastIndex = 10;
        FirstIndex = 0;
    }
    public void OnClickCasualButton()
    {   
        SelectButton.OutfitTurn = true;
        selectedOption = 10;
        updateOutfit(selectedOption);
        lastIndex = 20;
        FirstIndex = 10;
    }
    public void OnClickModernButton()
    {   
        SelectButton.OutfitTurn = true;
        selectedOption = 20;
        updateOutfit(selectedOption);
        lastIndex = 30;
        FirstIndex = 20;
    }
    public void OnClickOutfit()
    {
        lastIndex = 30;
        FirstIndex = 0;
    }

    public void OnLockOutfit()
    {
        Outfit outfit = db.GetOutfit(selectedOption);
        selectedOutfitValue = outfit.value;

        Debug.Log("this is the outfit score " + selectedOutfitValue);

    }
    public void UpdateValuesOutfit()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        foreach (Outfit o in db.outfits)
        {

            if (currentScene.name == "GameScene1")
            {
                if (o.isTraditional)
                {
                    o.value = Random.Range(-5, 0);

                }
                else if (o.isModern)
                {
                    o.value = Random.Range(4, 6);

                }
                else if (o.isCasual)
                {
                    o.value = Random.Range(7, 10);

                }
            }
            else if (currentScene.name == "GameScene2")
            {

                if (o.isTraditional)
                {
                    o.value = Random.Range(1, 3);

                }
                else if (o.isModern)
                {
                    o.value = Random.Range(7, 10);

                }
                else if (o.isCasual)
                {
                    o.value = Random.Range(1, 5);

                }
            }

            else if (currentScene.name == "GameScene3")
            {
                if (o.isTraditional)
                {
                    o.value = Random.Range(7, 10);

                }
                else if (o.isModern)
                {
                    o.value = Random.Range(4, 6);

                }
                else if (o.isCasual)
                {
                    o.value = Random.Range(1, 3);

                }
            }

        }
    }


}
