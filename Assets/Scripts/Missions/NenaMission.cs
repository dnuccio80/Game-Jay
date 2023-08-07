using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NenaMission : ExtraPlayerMission
{
    [SerializeField] GameObject potionsGame;
    [SerializeField] GameObject potionsGameUI;
    
    public override void StartMission()
    {
        potionsGame.SetActive(true);
        potionsGameUI.SetActive(true);
    }

    public override void RestartGame()
    {
        if (GeneralGameLogic.Instance.GetMissionNumber() == _numberMission)
        {
            potionsGame.SetActive(false);
            potionsGameUI.SetActive(false);
            exclamationSign.gameObject.SetActive(true);

            PotionsGameLogic.Instance.RestartGameStats();
        }
    }

}   
