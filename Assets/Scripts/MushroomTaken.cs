using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomTaken : MonoBehaviour
{

    [SerializeField] private PunchableObject boxParent;

    private void Awake()
    {
        boxParent = GetComponentInParent<PunchableObject>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            PotionsGameLogic.Instance.AddMushroom();
            SoundManagerScript.Instance.PlaySoundItemObtained();
            gameObject.SetActive(false);
            boxParent.InvokeDestroyObject(3f);
        }
    }

}
