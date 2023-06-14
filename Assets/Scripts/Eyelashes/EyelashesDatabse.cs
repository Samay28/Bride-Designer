using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class EyelashesDatabse : ScriptableObject
{
   public Eyelashes[] eyelashes;
    public int EyesLashescount
    {
        get
        {
            return eyelashes.Length;
        }
    }
    public Eyelashes GetEyelash(int index)
    {
        {
            return eyelashes[index];
        }
    }
}
