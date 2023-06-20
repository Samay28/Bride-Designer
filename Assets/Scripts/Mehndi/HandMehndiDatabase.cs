using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class HandMehndiDatabase : ScriptableObject
{
    public HandMehndi[] handMehndis;
    public int HandMehndiCount
    {
        get
        {
            return handMehndis.Length;
        }
    }
    public HandMehndi GetHandMehndi(int index)
    {
        {
            return handMehndis[index];
        }
    }
}
