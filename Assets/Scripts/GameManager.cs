using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public bool IsLevel1;
    private void Awake()
    {
        if (instance == null)
            instance = this;
    }
    private void Start()
    {
        IsLevel1 = true;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
