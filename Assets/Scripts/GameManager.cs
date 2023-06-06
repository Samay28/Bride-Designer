using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public static bool IsLevel1;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        IsLevel1 = true;
    }
    private void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
}
