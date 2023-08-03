using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class MagicianMission : ExtraPlayerMission
{

    public static MagicianMission Instance { get; private set; }


    [SerializeField] GameObject portalsGame;
    [SerializeField] GameObject portalsGameUI;

    public event EventHandler OnMagicianMissionRestart;

    private void Awake()
    {
        Instance = this;
    }

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
            OnMagicianMissionRestart?.Invoke(this, EventArgs.Empty);
            PetsUIScript.Instance.RestartGameStats();
            PortalsGameLogic.Instance.RestartGameStats();
        }
    }

}
