using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimerScript : MonoBehaviour
{
    public static TimerScript Instance { get; private set; }


    [SerializeField] private Image colorStat;
    [SerializeField] private Transform timeOverUI;
    [SerializeField] private  TextMeshProUGUI textTimer;
    private float timeMultiplíer;
    private float fillAmount = 1f;
    private float timer = 20f;

    private void Start()
    {
        Instance = this;
        GeneralGameLogic.Instance.OnMissionCompleted += Instance_OnMissionCompleted;
        textTimer.text = timer.ToString();
    }

    private void Instance_OnMissionCompleted(object sender, System.EventArgs e)
    {

    }

    void Update()
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
            gameObject.SetActive(false);
            timeOverUI.gameObject.SetActive(true);
        }
    }
 }

