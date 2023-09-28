using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraPlayerMission : MonoBehaviour
{

    private bool canInteract = false;
    private DialogueExtraPlayersUI interactionState;
    [SerializeField] public Transform exclamationSign;
    [SerializeField] public Transform timerUI;
    [SerializeField] public int _numberMission;

    private void Start()
    {
        interactionState = GetComponent<DialogueExtraPlayersUI>();
        StarterAssets.StarterAssetsInputs.Instance.OnInteractButtonPressed += StartesAssets_OnInteractButtonPressed;
        TimerScript.Instance.OnMissionTimeOver += TimerScript_OnMissionTimeOver;
        GeneralGameLogic.Instance.OnRestartByDead += GeneralGameLogic_OnRestartByDead;
    }

    private void GeneralGameLogic_OnRestartByDead(object sender, System.EventArgs e)
    {
        RestartGame();
    }

    private void TimerScript_OnMissionTimeOver(object sender, System.EventArgs e)
    {
        RestartGame();
    }

    private void StartesAssets_OnInteractButtonPressed(object sender, System.EventArgs e)
    {
        if(interactionState.GetIfCanInteract() && !interactionState.missionIsCompleted)
        {
            // Return bool isInMission
            if(!GeneralGameLogic.Instance.GetModeStatus())
            {
                GeneralGameLogic.Instance.ChangeInMissionMode(_numberMission);
                StartMission();
                exclamationSign.gameObject.SetActive(false);
            }
        }
    }


    public virtual void StartMission() { 
    
    }

    public virtual void RestartGame()
    {

    }

}
