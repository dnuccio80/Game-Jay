using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AuraObject : MonoBehaviour
{
    [SerializeField] private ParticleSystem aura;
    [SerializeField] private GameObject gameUI;
    [SerializeField] private GameObject game;
    [SerializeField] private Button buttonToDoList;
    [SerializeField] private Transform missionClearedUI;
    [SerializeField] private bool hasTimeOver;

    private void Awake()
    {
        gameObject.SetActive(false);
      
    }

    private void Start()
    {
        TimerScript.Instance.OnMissionTimeOver += TimerScript_OnMissionTimeOver;
    }

    private void TimerScript_OnMissionTimeOver(object sender, System.EventArgs e)
    {
        if(hasTimeOver)
        {
            gameObject.SetActive(false);
        }
    }

    private void Update()
    {
        Invoke("PlayAura", 3);
    }

    private void PlayAura()
    {
        aura.Play();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "InteractionZone")
        {
            GeneralGameLogic.Instance.ChangeInChillMode();
            GeneralGameLogic.Instance.MissionComplete();
            gameObject.SetActive(false);
            gameUI.SetActive(false);
            game.SetActive(false);
            buttonToDoList.interactable = false;
            missionClearedUI.gameObject.SetActive(true);
            GetComponentInParent<DialogueExtraPlayersUI>().missionIsCompleted = true;
        }
    }


}
