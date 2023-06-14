using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu]
public class HairstyleDatabase : ScriptableObject
{
    public Hairstyle[] Hairstyles;
    public int HairstyleCount
    {
        get{
            return Hairstyles.Length;
        }
    }
    public Hairstyle GetHairstyle(int index) {
        {
            return Hairstyles[index];
        }
    }
  
}
