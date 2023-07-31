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
        timerUI.gameObject.SetActive(true);
        
    }
}       
