using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class TutorialManager : MonoBehaviour
{
   public TextMeshProUGUI Dialogue;
   public GameObject Bride;
   public GameObject Anims;
    public GameObject Text;
   int count = 0;
    void Start()
    {
        Dialogue.text = "Hey there! Finally you got your first customer. But your dream of becoming a Successful wedding designer is still far away!";
        Bride.SetActive(false);
        Anims.SetActive(false);
        Text.SetActive(false);
    }

    // Update is called once per frame
   void Update()
{
    if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began && count == 0)
    {
        Dialogue.text = "Well as it's your first time, I can guide you through the basics";
        count++;
    }
    else if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began && count == 1)
    {
        Dialogue.text = "You will be personal designer of the girl, and you have to make sure that she is properly dressed for all the occasions!";
        Bride.SetActive(true);
        count++;
    }
    else if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began && count == 2)
    {
        Dialogue.text = "If you fail to make the groom happy, the girl might get rejected at any phase of the wedding.";
        Bride.SetActive(false);
        Text.SetActive(true);
        count++;
    }
    else if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began && count == 3)
    {
        Dialogue.text = "Swipe to change the designs, select the outfits, and other accessories according to the event.";
        Text.SetActive(false);
        Anims.SetActive(true);
        count++;
    }
    else if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began && count == 4)
    {
        Dialogue.text = "Good luck! I will see you next time!";
        Anims.SetActive(false);
        count++;
    }
    else if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began && count == 5)
    {
        Dialogue.text = "Oh, by the way, myself Sherry. Nice to meet you!";
        count++;
    }
    else if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began && count == 6)
    {
        SceneManager.LoadScene(1);
    }
}

}
