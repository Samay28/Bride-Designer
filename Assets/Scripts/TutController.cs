using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutController : MonoBehaviour
{
    public GameObject Swipe;
    void Start()
    {
        Swipe.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0) //checking for touch
        {
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                Swipe.SetActive(false);
            }
        }
    }
}
