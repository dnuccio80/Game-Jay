using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class GhostScript : MonoBehaviour
{
    [SerializeField] private GameObject interactivePanel;
    [SerializeField] public TextMeshProUGUI interactiveTextUI;
    [SerializeField] public AudioClip itemObtainedSound;
    [TextArea]
    [SerializeField] public string TextToInteractiveUI;
    [SerializeField] private GameObject panelGameUI;
    [SerializeField] private GameObject miniGameObjects;
    [Header("UI Section")]
    [SerializeField] private GameObject potionMovementUI;
    private Animator animator;
    public bool canGivePotion = false;
    private bool miniGameFinished = false;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            animator.SetBool("PlayerIsNear", true);
            interactivePanel.SetActive(true);
            interactiveTextUI.text = TextToInteractiveUI;


            if (canGivePotion)
            {
                PotionsGameLogic.Instance.AddPotion();
                potionMovementUI.SetActive(true);
                if (panelGameUI != null) panelGameUI.SetActive(false);
                miniGameObjects.SetActive(false);
                canGivePotion = false;
                PortalsGameLogic.Instance.ChangeMiniGameStatus(false);
                miniGameFinished = true;
                AudioSource.PlayClipAtPoint(itemObtainedSound, transform.position);
            }
            else if (!canGivePotion && !PortalsGameLogic.Instance.GetMiniGameStatus() && !miniGameFinished)
            {
                if (panelGameUI != null) panelGameUI.SetActive(true);
                miniGameObjects.SetActive(true);
                PortalsGameLogic.Instance.ChangeMiniGameStatus(true);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            animator.SetBool("PlayerIsNear", false);
            interactivePanel.SetActive(false);
        }
    }

}
