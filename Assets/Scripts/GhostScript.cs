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
    [SerializeField] protected string TextToInteractiveUI;
    [SerializeField] private GameObject panelGameUI;
    [SerializeField] private GameObject miniGameObjects;
    [Header("UI Section")]
    [SerializeField] private GameObject potionMovementUI;
    private Animator animator;
    protected string textGameDone = "Great! See you soon :)";
    public bool canGivePotion = false;
    protected bool miniGameFinished = false;

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

            if(canGivePotion)
            {
                interactiveTextUI.text = textGameDone;
            } else
            {
                interactiveTextUI.text = TextToInteractiveUI;
            }

            if (canGivePotion)
            {
                PotionsGameLogic.Instance.AddPotion();
                potionMovementUI.SetActive(true);
                if (panelGameUI != null) panelGameUI.SetActive(false);
                miniGameObjects.SetActive(false);
                canGivePotion = false;
                PotionsGameLogic.Instance.ChangeMiniGameStatus(false);
                miniGameFinished = true;
                AudioSource.PlayClipAtPoint(itemObtainedSound, transform.position);
            }
            else if (!canGivePotion && !PotionsGameLogic.Instance.GetMiniGameStatus() && !miniGameFinished)
            {
                if (panelGameUI != null) panelGameUI.SetActive(true);
                miniGameObjects.SetActive(true);
                PotionsGameLogic.Instance.ChangeMiniGameStatus(true);
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
