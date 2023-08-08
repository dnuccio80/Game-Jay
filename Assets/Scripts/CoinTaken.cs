using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinTaken : MonoBehaviour
{

    private void Start()
    {
        PotionsGameLogic.Instance.OnRestartGame += PotionsGameLogic_OnRestartGame;
    }

    private void PotionsGameLogic_OnRestartGame(object sender, System.EventArgs e)
    {
            gameObject.SetActive(true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            PotionsGameLogic.Instance.AddCoin();
            SoundManagerScript.Instance.PlaySoundItemObtained();
            gameObject.SetActive(false);
        }
    }

}
