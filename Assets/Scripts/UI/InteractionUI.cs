using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class InteractionUI : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI interactionText;
    [SerializeField] private ItemsToSpawnSO burguerToSpawn;
    [SerializeField] private Transform[] positionToSpawn;
    private bool canInteract = false;


    private void Awake()
    {
        interactionText.gameObject.SetActive(false);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "InteractionZone")
        {
            canInteract = true;
            interactionText.gameObject.SetActive(true);

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("InteractionZone"))
        {
            canInteract = false;
            interactionText.gameObject.SetActive(false);
        }
    }

    //public void Interact ()
    //{
    //    foreach (Transform positions in positionToSpawn)
    //    {
    //        Instantiate(burguerToSpawn.prefab, positions);
    //    }
    //}

    public bool GetIfCanInteract()
    {
        return canInteract;
    }
}
