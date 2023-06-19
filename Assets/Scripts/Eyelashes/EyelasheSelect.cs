using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EyelasheSelect : MonoBehaviour
{
    public EyelashesDatabse db;
    public SpriteRenderer SkinsUsed;
    private int selectedOption = 0;
    public static int selectedeyelashValue;

    //swipe
    Vector2 startTouchPos;
    Vector2 currentTouchPos;
    Vector2 endTouchPos;
    bool stopTouch = false;
    public float swipeRange;
    public float tapRange;

    private void Start()
    {
        foreach (Eyelashes e in db.eyelashes)
        {
                e.value = Random.Range(3, 8);
        }
        updateeye(0);
    }
    private void updateeye(int selectedOption)
    {
        this.selectedOption = selectedOption;
        Eyelashes eyes = db.GetEyelash(selectedOption);
        SkinsUsed.sprite = eyes.EyelashLook;

    }
    public void Swipe()
    {
        if (SelectButton.EyelashesTurn)
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
                        if (selectedOption == db.eyelashes.Length - 1)
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

    public void OnLockEyeLash()
    {
        Eyelashes eyes = db.GetEyelash(selectedOption);
        selectedeyelashValue = eyes.value;
<<<<<<< HEAD
        Debug.Log("this is the eyelash score " + selectedeyelashValue);
=======
        Debug.Log("this is the score " + selectedeyelashValue);
>>>>>>> 61fc34ef0dce2453d57397c91e1dead912e45055
    }

}
