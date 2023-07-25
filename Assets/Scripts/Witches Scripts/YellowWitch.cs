using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowWitch : GhostScript
{

    private void Start()
    {
        PotionsGameLogic.Instance.OnAllCoinsChatched += PotionsGameLogic_OnAllCoinsChatched;
    }

    private void PotionsGameLogic_OnAllCoinsChatched(object sender, System.EventArgs e)
    {
        TextToInteractiveUI = "Great! See you soon :)";
        canGivePotion = true;
    }
}
