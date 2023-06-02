using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu]
public class OutfitDatabase : ScriptableObject
{
    public Outfit[] outfits;
    public int OutfitCount
    {
        get{
            return outfits.Length;
        }
    }
    public Outfit GetOutfit(int index) {
        {
            return outfits[index];
        }
    }
  
}
