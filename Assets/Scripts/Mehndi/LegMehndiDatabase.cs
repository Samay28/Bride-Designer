using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class LegMehndiDatabase : ScriptableObject
{
    public LegMehndi[] LegMehndis;
    public int LegMehndiCount
    {
        get
        {
            return LegMehndis.Length;
        }
    }
    public LegMehndi GetLegMehndi(int index)
    {
        {
            return LegMehndis[index];
        }
    }
}
