using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedWitch : GhostScript
{


    private void Start()
    {
        PotionsGameLogic.Instance.OnAllMushroomCatched += PotionsGameLogic_OnAllMushroomCatched;
    }

    private void PotionsGameLogic_OnAllMushroomCatched(object sender, System.EventArgs e)
    {
        TextToInteractiveUI = "Great! See you soon :)";
        canGivePotion = true;
    }
}
