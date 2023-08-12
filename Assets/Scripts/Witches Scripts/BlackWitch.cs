using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackWitch : GhostScript
{

    private void Start()
    {
        PotionsGameLogic.Instance.OnZombieArrive += PotionsGameLogic_OnZombieArrive;
        PotionsGameLogic.Instance.OnRestartGame += PotionsGameLogic_OnRestartGame;
    }

    private void PotionsGameLogic_OnRestartGame(object sender, System.EventArgs e)
    {
        canGivePotion = false;
        miniGameFinished = false;
        PotionsGameLogic.Instance.ChangeMiniGameStatus(false);

    }

    private void PotionsGameLogic_OnZombieArrive(object sender, System.EventArgs e)
    {
        canGivePotion = true;
    }
}
