using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class CubicGameLogic : MonoBehaviour
{

    public event EventHandler OnAllCubicPosicioned;

    public static CubicGameLogic Instance { get; private set; }
    private float totalCubics;
    public bool hasAnObject = false;
    private int numberCoincidence;

    private void Awake()
    {
        totalCubics = 4f;
        Instance = this;

    }

    public void IncreaseCoincidence()
    {
        numberCoincidence++;
        if (numberCoincidence == totalCubics)
        {
            OnAllCubicPosicioned?.Invoke(this, EventArgs.Empty);

        }
    }

    public bool GetIfHasAnObject()
    {
        return hasAnObject;
    }



}
