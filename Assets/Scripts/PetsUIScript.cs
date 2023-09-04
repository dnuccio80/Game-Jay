using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PetsUIScript : MonoBehaviour
{
    public static PetsUIScript Instance { get; private set; }

    [SerializeField] private TextMeshProUGUI petCountText;
    [SerializeField] private int petsQuantity;
    [SerializeField] private Transform aura;


    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        petCountText.text = petsQuantity.ToString();
        PortalsGameLogic.Instance.onPetCatched += Instance_onPetCatched;
    }

    private void Instance_onPetCatched(object sender, System.EventArgs e)
    {
        petsQuantity--;
        petCountText.text = petsQuantity.ToString();

        if (petsQuantity == 0)
        {
            aura.gameObject.SetActive(true);
        }

    } 

    public void RestartGameStats()
    {
        petsQuantity = 4;
        petCountText.text = petsQuantity.ToString();
        aura.gameObject.SetActive(false);
    }
}
