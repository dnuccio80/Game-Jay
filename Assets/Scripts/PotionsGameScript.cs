using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionsGameScript : MonoBehaviour
{

    [SerializeField] private Transform pandoraBoxesContainer;
    [SerializeField] private Transform coinsContainer;

    private void Start()
    {
        PotionsGameLogic.Instance.OnRestartGame += PotionsGameLogic_OnRestartGame;
    }

    private void PotionsGameLogic_OnRestartGame(object sender, System.EventArgs e)
    {
        pandoraBoxesContainer.gameObject.SetActive(false);
        coinsContainer.gameObject.SetActive(false);
            
    }
}
