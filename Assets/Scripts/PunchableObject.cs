using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PunchableObject : MonoBehaviour
{
    private bool canInteract = false;
    private bool broken = false;
    [SerializeField] private Transform normalBox;
    [SerializeField] private Transform destroyedBox;
    [SerializeField] private Transform objectInside;
    [SerializeField] private Transform interactText;

    // Start is called before the first frame update
    void Start()
    {
        StarterAssets.StarterAssetsInputs.Instance.OnInteractButtonPressed += StarterAssets_OnInteractButtonPressed;
        PotionsGameLogic.Instance.OnRestartGame += PotionsGameLogic_OnRestartGame;
    }

    private void PotionsGameLogic_OnRestartGame(object sender, System.EventArgs e)
    {
        gameObject.SetActive(true);
        normalBox.gameObject.SetActive(true);
        destroyedBox.gameObject.SetActive(false);
        objectInside.gameObject.SetActive(false);
        objectInside.SetParent(gameObject.transform);
        broken = false;
    }

    private void StarterAssets_OnInteractButtonPressed(object sender, System.EventArgs e)
    {
        if(canInteract)
        {
            normalBox.gameObject.SetActive(false);
            destroyedBox.gameObject.SetActive(true);
            objectInside.gameObject.SetActive(true);
            interactText.gameObject.SetActive(false);
            broken = true;
        }
    }       

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            canInteract = true;
            if(!broken) interactText.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            canInteract = false;
            interactText.gameObject.SetActive(false);
        }

    }

    private void DestroyObject()
    {
        gameObject.SetActive(false);
    }

    public void InvokeDestroyObject(float time)
    {
        Invoke("DestroyObject", time);
    }


}
