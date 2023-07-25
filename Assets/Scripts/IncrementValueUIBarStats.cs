using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IncrementValueUIBarStats : MonoBehaviour
{

    [SerializeField] private Image colorStat;
    private float fillAmount = 0f;

    private void OnEnable()
    {
        colorStat.fillAmount = 0f;
    }

    void Update()
    {
        if(fillAmount < 0.25f)
        {
            fillAmount += 0.005f;
            colorStat.fillAmount = fillAmount;
        }
    }
}
