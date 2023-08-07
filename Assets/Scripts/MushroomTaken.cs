using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomTaken : MonoBehaviour
{


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            PotionsGameLogic.Instance.AddMushroom();
            SoundManagerScript.Instance.PlaySoundItemObtained();
            //Destroy(gameObject);
            gameObject.SetActive(false);
        }
    }

}
