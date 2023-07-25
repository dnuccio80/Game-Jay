using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraPlayerMission : MonoBehaviour
{
    private bool canInteract = false;
    private DialogueExtraPlayersUI interactionState;
    [SerializeField] private Transform exclamationSign;

    private void Start()
    {
        interactionState = GetComponent<DialogueExtraPlayersUI>();
        StarterAssets.StarterAssetsInputs.Instance.OnInteractButtonPressed += StartesAssets_OnInteractButtonPressed;
    }

    private void StartesAssets_OnInteractButtonPressed(object sender, System.EventArgs e)
    {
        if(interactionState.GetIfCanInteract() && !interactionState.missionIsCompleted)
        {
            if(!GeneralGameLogic.Instance.GetModeStatus())
            {
                GeneralGameLogic.Instance.ChangeInMissionMode();
                StartMission();
                exclamationSign.gameObject.SetActive(false);
            }
        }
    }


    public virtual void StartMission() { 
    
    }

}
