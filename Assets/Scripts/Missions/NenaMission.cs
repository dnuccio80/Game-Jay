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
}   
