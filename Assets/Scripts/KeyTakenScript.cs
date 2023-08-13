using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyTakenScript : MonoBehaviour
{

    [SerializeField] private Transform aura;


    private void Start()
    {
        PotionsGameLogic.Instance.OnRestartGame += PotionsGameLogic_OnRestartGame;
    }

    private void PotionsGameLogic_OnRestartGame(object sender, System.EventArgs e)
    {
        gameObject.SetActive(true);
        aura.gameObject.SetActive(true);

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            gameObject.SetActive(false);
            aura.gameObject.SetActive(true);
            SoundManagerScript.Instance.PlaySoundItemObtained();
        }
    }

}
