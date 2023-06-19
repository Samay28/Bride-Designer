using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu]
public class JewelleryDatabase : ScriptableObject
{
    public Jewellery[] Jewelleries;
    public int JewelleryCount
    {
        get{
            return Jewelleries.Length;
        }
    }
    public Jewellery GetJewellery(int index) {
        {
            return Jewelleries[index];
        }
    }
  
}
