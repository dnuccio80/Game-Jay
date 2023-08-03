using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicianMission : ExtraPlayerMission
{

    [SerializeField] GameObject portalsGame;
    [SerializeField] GameObject portalsGameUI;
    public override void StartMission()
    {
        portalsGame.SetActive(true);
        portalsGameUI.SetActive(true);
    }


    public override void RestartGame()
    {
        if (GeneralGameLogic.Instance.GetMissionNumber() == _numberMission)
        {
            portalsGame.SetActive(false);
            portalsGameUI.SetActive(false);
            exclamationSign.gameObject.SetActive(true);

            PetsUIScript.Instance.RestartGameStats();
            PortalsGameLogic.Instance.RestartGameStats();
        }
    }

}
