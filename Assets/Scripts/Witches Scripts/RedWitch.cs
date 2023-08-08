using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedWitch : GhostScript
{


    private void Start()
    {
        PotionsGameLogic.Instance.OnAllMushroomCatched += PotionsGameLogic_OnAllMushroomCatched;
        PotionsGameLogic.Instance.OnRestartGame += PotionsGameLogic_OnRestartGame;
    }

    private void PotionsGameLogic_OnRestartGame(object sender, System.EventArgs e)
    {
        miniGameFinished = false;
        PotionsGameLogic.Instance.ChangeMiniGameStatus(false);
        canGivePotion = false;
    }

    private void PotionsGameLogic_OnAllMushroomCatched(object sender, System.EventArgs e)
    {
        
        canGivePotion = true;
    }


}
