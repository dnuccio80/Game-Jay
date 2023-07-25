using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PetsUIScript : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI petCountText;
    [SerializeField] private int petsQuantity;
    [SerializeField] private Transform greenTick;
    [SerializeField] private Transform aura;

    void Start()
    {
        petCountText.text = petsQuantity.ToString();
        PortalsGameLogic.Instance.onPetCatched += Instance_onPetCatched;
    }

    private void Instance_onPetCatched(object sender, System.EventArgs e)
    {
        petsQuantity--;
        petCountText.text = petsQuantity.ToString();
        
        if(petsQuantity == 0)
        {
            greenTick.gameObject.SetActive(true);
            aura.gameObject.SetActive(true);
        }

    }
}
