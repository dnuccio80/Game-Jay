using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowWitch : GhostScript
{

    private void Start()
    {
        PotionsGameLogic.Instance.OnAllCoinsChatched += PotionsGameLogic_OnAllCoinsChatched;
        PotionsGameLogic.Instance.OnRestartGame += PotionsGameLogic_OnRestartGame;
    }

    private void PotionsGameLogic_OnRestartGame(object sender, System.EventArgs e)
    {
        canGivePotion = false;
        miniGameFinished = false;
        PotionsGameLogic.Instance.ChangeMiniGameStatus(false);
    }

    private void PotionsGameLogic_OnAllCoinsChatched(object sender, System.EventArgs e)
    {
        canGivePotion = true;
    }
}
