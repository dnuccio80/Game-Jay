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


}
