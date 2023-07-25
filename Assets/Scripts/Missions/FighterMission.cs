using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FighterMission : ExtraPlayerMission
{
    [SerializeField] GameObject cubicGame;
    [SerializeField] GameObject cubicGameUI;
    public override void StartMission()
    {
        cubicGame.SetActive(true);
        cubicGameUI.SetActive(true);
    }
}   
