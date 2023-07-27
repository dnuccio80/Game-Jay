using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour
{
    public static TimerScript Instance { get; private set; }


    [SerializeField] private Image colorStat;
    private float timeMultiplíer;
    private float fillAmount = 1f;

    private void Start()
    {
        Instance = this;
    }

    void Update()
    {
        if (fillAmount > 0f)
        {
            fillAmount -= Time.deltaTime * timeMultiplíer;
            colorStat.fillAmount = fillAmount;
        } else
        {
            gameObject.SetActive(false);
            RestartTimer();
        }
    }

    private void RestartTimer()
    {
        fillAmount = 1f;
    }

    public void SetTimeMultiplier(float value)
    {
        timeMultiplíer = value;
    }
}
