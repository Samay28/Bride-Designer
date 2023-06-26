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

    private void Start()
    {
        updateOutfit(0);
        UpdateValuesOutfit();
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
                            if (selectedOption == 0)
                                return;
                            else
                                selectedOption--;
                            updateOutfit(selectedOption);
                            stopTouch = true;
                        }
                        else if (Distance.x > swipeRange)
                        {
                            if (selectedOption == db.outfits.Length - 1)
                                selectedOption = 0;
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
