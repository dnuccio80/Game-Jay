using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeneMission : ExtraPlayerMission
{
    [SerializeField] GameObject hamburguersGame;
    [SerializeField] GameObject hamburguersGameUI;

    public override void StartMission()
    {
        hamburguersGame.SetActive(true);
        hamburguersGameUI.SetActive(true);
        TimerScript.Instance.SetTimerCount(10f);
        timerUI.gameObject.SetActive(true);
        
    }

    public override void RestartGame()
    {
        if (GeneralGameLogic.Instance.GetMissionNumber() == _numberMission)
        {
            hamburguersGame.SetActive(false);
            hamburguersGameUI.SetActive(false);
            exclamationSign.gameObject.SetActive(true);
        }
    }
}       
