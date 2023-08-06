using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PunchableObject : MonoBehaviour
{
    private bool canInteract = false;
    [SerializeField] private Transform normalBox;
    [SerializeField] private Transform destroyedBox;
    [SerializeField] private Transform objectInside;

    // Start is called before the first frame update
    void Start()
    {
        StarterAssets.StarterAssetsInputs.Instance.OnInteractButtonPressed += StarterAssets_OnInteractButtonPressed;
        PotionsGameLogic.Instance.OnRestartGame += PotionsGameLogic_OnRestartGame;
    }

    private void PotionsGameLogic_OnRestartGame(object sender, System.EventArgs e)
    {
        normalBox.gameObject.SetActive(true);
        destroyedBox.gameObject.SetActive(false);
        objectInside.gameObject.SetActive(false);
        objectInside.SetParent(gameObject.transform);
    }

    private void StarterAssets_OnInteractButtonPressed(object sender, System.EventArgs e)
    {
        if(canInteract)
        {
            normalBox.gameObject.SetActive(false);
            destroyedBox.gameObject.SetActive(true);
            Invoke("DestroyObject", 7 );
            objectInside.gameObject.SetActive(true);
            objectInside.SetParent(null);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            canInteract = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            canInteract = false;
        }

    }

    private void DestroyObject()
    {
        //Destroy(gameObject);
        gameObject.SetActive(false);
    }


}
