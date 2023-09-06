using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System;
using UnityEngine.Playables;
using UnityEngine.UI;

public class GeneralGameLogic : MonoBehaviour
{
    public static GeneralGameLogic Instance { get; private set; }

    [Header("UI")]
    [SerializeField] GameObject interactText;
    [SerializeField] GameObject missionCompleteUI;
    [SerializeField] Transform ToDoListUI;
    [SerializeField] Transform pauseGameUI;
    [SerializeField] Transform gameOverUI;
    [Header("Buttons")]
    [SerializeField] Button closeToDoListButton;
    [SerializeField] Button backButtonExplanation;
    [SerializeField] Button backButtonGamePause;
    [SerializeField] Button backButtonControlsUI;
    [SerializeField] Button resumeButtonGamePause;
    [SerializeField] Button restartButtonGameOver;
    [Header("Timelines")]
    [SerializeField] private PlayableDirector restartGameTimeline;
    [SerializeField] private PlayableDirector startTimeline;
    [SerializeField] private PlayableDirector EndingGameTimeline;

    private bool isInMission = false;
    public event EventHandler OnMissionCompleted;
    public event EventHandler OnMissionPlaying;
    public event EventHandler OnMissionTimeOver;
    public event EventHandler OnRestartByDead;
    public event EventHandler OnAllMissionsCompleted;
    private LookMouse lookMouse;
    public int numberMission;
    private int missionsCompleted;

    private HamburguersGameLogic hamburguersGameLogic;

    private void Awake()
    {
        if (GeneralGameLogic.Instance == null)
        {
            Instance = this;
        } else
        {
            Destroy(gameObject);
        }
        missionsCompleted = 3;
        LoadLevelScene();
        lookMouse = GetComponent<LookMouse>();
        hamburguersGameLogic = GetComponent<HamburguersGameLogic>();
    }


    private void Start()
    {
        StarterAssets.StarterAssetsInputs.Instance.OnInteractAlternatePressed += StarterAssets_OnInteractAlternatePressed;
        StarterAssets.StarterAssetsInputs.Instance.OnReturnButtonPressed += StarterAssets_OnReturnButtonPressed;
        PlayerStats.Instance.OnPlayerDeath += PlayerStats_OnPlayerDeath;
        TimerScript.Instance.OnMissionTimeOver += TimerScript_OnMissionTimeOver;
        PlayStartTimeline();
    }

    private void TimerScript_OnMissionTimeOver(object sender, EventArgs e)
    {

        //// If want to add timer to other missions;
        //switch(numberMission)
        //{
        //    case 1:
        //        hamburguersGameLogic.RestartGameStats();
        //        break;
        //    case 2:
        //        break;
        //    case 3:
        //        break;
        //    case 4:
        //        break;
        //    case 5:
        //        break;
        //}

        ChangeInChillMode();
        MusicManagerScript.Instance.PlayTimeOverMusic();
    }


    public void RestartByDead()
    {
        OnRestartByDead?.Invoke(this, EventArgs.Empty);
    }

    private void PlayerStats_OnPlayerDeath(object sender, EventArgs e)
    {
        gameOverUI.gameObject.SetActive(true);
        lookMouse.UnlockMouse();
        restartButtonGameOver.Select();
    }

    private void StarterAssets_OnReturnButtonPressed(object sender, EventArgs e)
    {


        if (backButtonExplanation.gameObject.activeInHierarchy)
        {
            backButtonExplanation.onClick.Invoke();

        } else if (backButtonControlsUI.gameObject.activeInHierarchy)
        {
            backButtonControlsUI.onClick.Invoke();

        } else if (closeToDoListButton.gameObject.activeInHierarchy)
        {
            closeToDoListButton.onClick.Invoke();
        } else if (!pauseGameUI.gameObject.activeInHierarchy)
        {
            if (!gameOverUI.gameObject.activeInHierarchy)
            {
                pauseGameUI.gameObject.SetActive(true);
                resumeButtonGamePause.Select();
                HandleTimeScale(0f);
                lookMouse.UnlockMouse();
                StarterAssets.StarterAssetsInputs.Instance.ChangeCharacterControllerStatus(false);
            }

        } else if (pauseGameUI.gameObject.activeInHierarchy)
        {
            backButtonGamePause.onClick.Invoke();
            StarterAssets.StarterAssetsInputs.Instance.ChangeCharacterControllerStatus(true);

        }
    }

    private void StarterAssets_OnInteractAlternatePressed(object sender, EventArgs e)
    {
        if (!backButtonGamePause.gameObject.activeInHierarchy && !gameOverUI.gameObject.activeInHierarchy)
        {
            HandleToDoList(true);
            lookMouse.UnlockMouse();
            closeToDoListButton.Select();
        }

    }

    private void Update()
    {
        if (isInMission)
        {
            interactText.SetActive(false);
        }
        else
        {
            interactText.SetActive(true);
        }
    }


    public void ChangeInMissionMode(int _numberMission)
    {
        isInMission = true;
        OnMissionPlaying?.Invoke(this, EventArgs.Empty);
        numberMission = _numberMission;
    }

    public void MissionComplete()
    {
        IncrementMissionsCompleted();
        OnMissionCompleted?.Invoke(this, EventArgs.Empty);
        if(missionsCompleted < 5) missionCompleteUI.SetActive(true);
    }


    public void ChangeInChillMode()
    {
        isInMission = false;
    }

    public bool GetModeStatus()
    {
        return isInMission;
    }

    public void LoadLevelScene() {
        SceneManager.LoadSceneAsync("Level1Game", LoadSceneMode.Additive);
    }

    public void RemoveTrainingScene()
    {
        SceneManager.UnloadSceneAsync("Training");
    }

    public void GoToIntroScene()
    {
        SceneManager.LoadSceneAsync("Intro", LoadSceneMode.Single);
    }

    private void HandleToDoList(bool status)
    {
        ToDoListUI.gameObject.SetActive(status);
    }

    public void HandleTimeScale(float value)
    {
        Time.timeScale = value;
    }

    public int GetMissionNumber()
    {
        return numberMission;
    }

    public void PlayRestartTimeline()
    {
        restartGameTimeline.Play();
    }

    private void PlayStartTimeline()
    {
        startTimeline.Play();
    } 

    private void IncrementMissionsCompleted()
    {
        missionsCompleted++;

        if(missionsCompleted == 5)
        {
            EndingGameTimeline.Play();
            OnAllMissionsCompleted?.Invoke(this, EventArgs.Empty);
        }
    }

    public bool GetIfAllMissionsCompleted()
    {
        if (missionsCompleted == 5) return true;
        else return false;
    }
}
    