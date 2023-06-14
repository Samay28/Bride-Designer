using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class LipsDatabase : ScriptableObject
{
    public Lips[] lips;
    public int LipsCount
    {
        get
        {
            return lips.Length;
        }
    }
    public Lips GetLips(int index)
    {
        {
            return lips[index];
        }
    }
}
