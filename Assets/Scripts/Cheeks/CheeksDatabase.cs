using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class CheeksDatabase : ScriptableObject
{   
    public Cheeks[] cheeks;
    public int CheeksCount
    {
        get
        {
            return cheeks.Length;
        }
    }
    public Cheeks GetCheeks(int index)
    {
        {
            return cheeks[index];
        }
    }
}
