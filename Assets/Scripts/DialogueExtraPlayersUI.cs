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
    [SerializeField] string textDialogueEnglish;
    [TextArea]
    [SerializeField] string textDialogueSpanish;
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
                    if (PlayerPrefs.GetInt("language") == 0)
                    {
                        dialogueUI.text = textDialogueEnglish;
                    }
                    else if (PlayerPrefs.GetInt("language") == 1)
                    {
                        dialogueUI.text = textDialogueSpanish;
                    }



                }
                else
                {
                    if(PlayerPrefs.GetInt("language") == 0)
                    {
                        dialogueUI.text = "You are already in a Mission";
                    }
                    else if(PlayerPrefs.GetInt("language") == 1)
                    {
                        dialogueUI.text = "Ya estás en una misión";
                    }
                }
            } else
            {

                if(PlayerPrefs.GetInt("language") == 0)
                {
                    dialogueUI.text = "Thanks for helping me ! :)";
                }
                else if (PlayerPrefs.GetInt("language") == 1)
                {
                   dialogueUI.text = "Gracias por ayudarme ! :)";
                }
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
