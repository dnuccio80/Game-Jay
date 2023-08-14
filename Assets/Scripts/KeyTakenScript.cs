using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyTakenScript : MonoBehaviour
{

    [SerializeField] private Transform aura;


    private void Start()
    {
        CubicGameLogic.Instance.OnRestartGame += CubicGameLogic_OnRestartGame;
    }

    private void CubicGameLogic_OnRestartGame(object sender, System.EventArgs e)
    {
        gameObject.SetActive(true);
        aura.gameObject.SetActive(false);

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
