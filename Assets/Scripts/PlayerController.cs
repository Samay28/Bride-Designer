using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public CameraController cm;
    public static PlayerController instance;
    public bool zoomed;
    public GameObject Outfit;
    public GameObject Neck;
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        Neck.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
    }
    public void SetPos()
    {
        transform.position = new Vector2(transform.position.x, -1.64f);
        cm.StartCameraMovement();
        zoomed = true;
        Invoke("NeckActive", 0.5f);
    }
    public void SetInPos()
    {   
        if(zoomed)
        cm.Retract();
        zoomed = false;
        transform.position = new Vector2(transform.position.x, 0f);
        Neck.SetActive(false);
        Outfit.SetActive(true);
    }
    public void SetPos1()
    {   
        if(!zoomed)
        {
        transform.position = new Vector2(transform.position.x, -2.1f);
        cm.StartCamMove1();
        zoomed = true;
        Invoke("NeckActive", 0.5f);
        }
    }
    public void NeckActive()
    {
        Neck.SetActive(true);
        Outfit.SetActive(false);
    }
   
    

}