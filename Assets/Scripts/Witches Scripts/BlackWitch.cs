using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackWitch : GhostScript
{

    private void Start()
    {
        PotionsGameLogic.Instance.OnZombieArrive += PotionsGameLogic_OnZombieArrive;
    }

    private void PotionsGameLogic_OnZombieArrive(object sender, System.EventArgs e)
    {
        TextToInteractiveUI = "Great! See you soon :)";
        canGivePotion = true;
    }
}
