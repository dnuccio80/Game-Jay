using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System;
using UnityEngine.UI;

public class GeneralGameLogic : MonoBehaviour
{
    public static GeneralGameLogic Instance { get; private set; }

    [Header ("UI")]
    [SerializeField] GameObject interactText;
    [SerializeField] GameObject missionCompleteUI;
    [SerializeField] Transform ToDoListUI;
    [SerializeField] Transform pauseGameUI;
    [SerializeField] Transform gameOverUI;
    [Header ("Buttons")]
    [SerializeField] Button closeToDoListButton;
    [SerializeField] Button backButtonExplanation;
    [SerializeField] Button backButtonGamePause;
    [SerializeField] Button backButtonControlsUI;
    [SerializeField] Button resumeButtonGamePause;
    [SerializeField] Button restartButtonGameOver;
    private bool isInMission = false;
    public event EventHandler OnMissionCompleted;
    public event EventHandler OnMissionPlaying;
    public event EventHandler OnMissionTimeOver;
    private LookMouse lookMouse;


    private void Awake()
    {
        Instance = this;
        LoadLevelScene();
        lookMouse = GetComponent<LookMouse>();
    }


    private void Start()
    {
        StarterAssets.StarterAssetsInputs.Instance.OnInteractAlternatePressed += StarterAssets_OnInteractAlternatePressed;
        StarterAssets.StarterAssetsInputs.Instance.OnReturnButtonPressed += StarterAssets_OnReturnButtonPressed;
        PlayerStats.Instance.OnPlayerDeath += PlayerStats_OnPlayerDeath;
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
        if(!backButtonGamePause.gameObject.activeInHierarchy && !gameOverUI.gameObject.activeInHierarchy)
        {
            HandleToDoList(true);
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

    public void MissionComplete()
    {
        OnMissionCompleted?.Invoke(this, EventArgs.Empty);
        missionCompleteUI.SetActive(true);
    }

    public void ChangeInMissionMode()
    {
        isInMission = true;
        OnMissionPlaying?.Invoke(this, EventArgs.Empty);
    }

    public void MissionTimeOVer()
    {
        isInMission = false;
        OnMissionTimeOver?.Invoke(this, EventArgs.Empty);
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
}
    