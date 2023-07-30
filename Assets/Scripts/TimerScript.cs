using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour
{
    public static TimerScript Instance { get; private set; }


    [SerializeField] private Image colorStat;
    [SerializeField] private Transform timeOverUI;
    private float timeMultiplíer;
    private float fillAmount = 1f;

    private void Start()
    {
        Instance = this;
        GeneralGameLogic.Instance.OnMissionCompleted += Instance_OnMissionCompleted;
    }

    private void Instance_OnMissionCompleted(object sender, System.EventArgs e)
    {
        RestartTimer();
    }

    private void OnEnable()
    {
        SetTimeMultiplier(.3f);
    }

    void Update()
    {
        if (fillAmount > 0f)
        {
            fillAmount -= Time.deltaTime * timeMultiplíer;
            colorStat.fillAmount = fillAmount;
            if(fillAmount < 0.25f)
            {
                colorStat.color = Color.red;
            } else
            {
                colorStat.color = Color.cyan;
            }
        } else
        {
            timeOverUI.gameObject.SetActive(true);
            RestartTimer();
        }   
    }

    private void RestartTimer()
    {
        gameObject.SetActive(false);
        fillAmount = 1f;
    }

    public void SetTimeMultiplier(float value)
    {
        timeMultiplíer = value;
    }
}
