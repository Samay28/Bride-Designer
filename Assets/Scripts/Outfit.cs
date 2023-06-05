using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]

public class Outfit
// Start is called before the first frame update
{
    public bool isTraditional;
    public bool isModern;
    public bool isCasual;
    public Sprite OutfitLook;
    public int value;

    private void Start()
    {   
        if(GameManager.instance.IsLevel1)
        if(isTraditional)
        {
            value = Random.Range(1, 3);
        }
        else if(isModern)
        {
            value = Random.Range(4,6);
        }
        else if(isCasual)
        {
            value = Random.Range(7,10);
        }
    }
}

