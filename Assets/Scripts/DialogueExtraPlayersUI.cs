using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueExtraPlayersUI : MonoBehaviour
{

    [SerializeField] private GameObject canvasDialogue;
    [SerializeField] private TextMeshProUGUI dialogueUI;
    [SerializeField] private GameObject interactTextUI;
    [TextArea]
    [SerializeField] string textDialogue;
    private Animator animator;
    private bool canInteract = false;
    public bool missionIsCompleted = false;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.tag == "InteractionZone")
        {
            canInteract = true;
            animator.SetBool("IsTalking", true);
            if(!GeneralGameLogic.Instance.GetIfAllMissionsCompleted()) canvasDialogue.SetActive(true);
            if(!missionIsCompleted)
            {
                if (!GeneralGameLogic.Instance.GetModeStatus())
                {
                    dialogueUI.text = textDialogue;
                }
                else
                {
                    dialogueUI.text = "You are already in a Mission";
                }
            } else
            {
                dialogueUI.text = "Thanks for helping me ! :)";
                canInteract = false;
            }
            
            
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "InteractionZone")
        {
            if (GeneralGameLogic.Instance.GetIfAllMissionsCompleted()) canvasDialogue.SetActive(false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "InteractionZone")
        {
            canInteract = false;
            animator.SetBool("IsTalking", false);
            canvasDialogue.SetActive(false);
        }
    }

    public bool GetIfCanInteract()
    {
        return canInteract;
    }

  

}
