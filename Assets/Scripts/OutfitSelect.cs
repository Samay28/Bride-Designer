using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class OutfitSelect : MonoBehaviour
{   
    public OutfitDatabase db;
    public SpriteRenderer SkinsUsed;
    private int selectedOption = 0;
    public Button[] select;

    public void OnClickMe0()
    {
        updateOutfit(1);
    }
    private void updateOutfit(int selectedOption)
    {
        Outfit outfit = db.GetOutfit(selectedOption);
        SkinsUsed.sprite = outfit.OutfitLook;
    }
}   
