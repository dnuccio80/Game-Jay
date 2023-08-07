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
        canGivePotion = false;
        interactiveTextUI.text = TextToInteractiveUI;
        PortalsGameLogic.Instance.ChangeMiniGameStatus(false);
    }

    private void PotionsGameLogic_OnAllMushroomCatched(object sender, System.EventArgs e)
    {
        TextToInteractiveUI = "Great! See you soon :)";
        canGivePotion = true;
    }


}
