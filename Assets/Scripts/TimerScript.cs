using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class TimerScript : MonoBehaviour
{
    public static TimerScript Instance { get; private set; }

    [SerializeField] private Transform timeOverUI;
    [SerializeField] private  TextMeshProUGUI textTimer;

    public event EventHandler OnMissionTimeOver;

    private float timer = 20f;

    private void Start()
    {
        Instance = this;
        GeneralGameLogic.Instance.OnMissionCompleted += Instance_OnMissionCompleted;
        PlayerStats.Instance.OnPlayerDeath += PlayerStats_OnPlayerDeath;
        textTimer.text = timer.ToString();
    }

    private void PlayerStats_OnPlayerDeath(object sender, EventArgs e)
    {
        textTimer.gameObject.SetActive(false);
        RestartTimerCount();
    }

    private void Instance_OnMissionCompleted(object sender, System.EventArgs e)
    {
        textTimer.gameObject.SetActive(false);
        RestartTimerCount();
    }

    void Update()
    {
        if(textTimer.gameObject.activeInHierarchy)
        {
            if (timer > 0f)
            {
                timer -= Time.deltaTime * .9f;
                textTimer.text = Mathf.Round(timer).ToString();
                if (timer < 10f)
                {
                    textTimer.color = Color.red;
                }
                else
                {
                    textTimer.color = Color.cyan;

                }
            }
            else
            {
                textTimer.gameObject.SetActive(false);
                timeOverUI.gameObject.SetActive(true);
                OnMissionTimeOver?.Invoke(this, EventArgs.Empty);
            }
        }
      
    }

    public void SetTimerCount(float value)
    {
        timer = value;
    }

    public void RestartTimerCount()
    {
        timer = 20f;
    }
 }

