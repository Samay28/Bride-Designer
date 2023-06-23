using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public CameraController cm;
    public static PlayerController instance;
    public bool zoomed;
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
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
    }
    public void SetInPos()
    {   
        if(zoomed)
        cm.Retract();
        zoomed = false;
        transform.position = new Vector2(transform.position.x, 0f);
    }
    public void SetPos1()
    {   
        if(!zoomed)
        {
        transform.position = new Vector2(transform.position.x, -1.7f);
        cm.startCamMove1();
        zoomed = true;
        }
        // else 
        // {
        //     transform.position = new Vector2(transform.position.x, -1.7f);
        // }
    }
}
