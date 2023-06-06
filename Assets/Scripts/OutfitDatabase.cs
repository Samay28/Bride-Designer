using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu]
public class OutfitDatabase : ScriptableObject
{
    public Outfit[] outfits;
    private void Start()
    {

    }
    public int OutfitCount
    {
        get
        {
            return outfits.Length;
        }
    }
    public Outfit GetOutfit(int index)
    {
        {
            return outfits[index];
        }
    }


}
