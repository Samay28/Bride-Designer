using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class EyebrowsDatabase : ScriptableObject
{
    
    public Eyebrows[] eyebrows;
    public int eyebrowsCount
    {
        get
        {
            return eyebrows.Length;
        }
    }
    public Eyebrows GetEyebrows(int index)
    {
        {
            return eyebrows[index];
        }
    }
}
