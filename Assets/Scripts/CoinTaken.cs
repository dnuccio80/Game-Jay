using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinTaken : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            PotionsGameLogic.Instance.AddCoin();
            SoundManagerScript.Instance.PlaySoundItemObtained();
            Destroy(gameObject);
        }
    }
}
