using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectButton : MonoBehaviour
{
    public static bool Hairturn = true;
    public static bool OutfitTurn = false;   

    void Awake()
    {
       Hairturn = true;
       OutfitTurn = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void HairButton()
    {
        Hairturn = true;
        OutfitTurn = false;
    }
    public void OutfitButton()
    {
        OutfitTurn = true;
        Hairturn = false;
    }
}
