using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LadyMission : ExtraPlayerMission
{

    [SerializeField] GameObject lettersGame;
    [SerializeField] GameObject lettersGameUI;
    public override void StartMission()
    {
        lettersGame.SetActive(true);
        lettersGameUI.SetActive(true);
    }






}
