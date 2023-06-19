using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu]
public class EyesDatabase : ScriptableObject
{
    public Eyes[] eye;
    public int Eyescount
    {
        get
        {
            return eye.Length;
        }
    }
    public Eyes GetEye(int index)
    {
        {
            return eye[index];
        }
    }

}
