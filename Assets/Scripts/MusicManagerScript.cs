using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicManagerScript : MonoBehaviour
{

    public static MusicManagerScript Instance { get; private set; }
    private AudioSource audioSource;

    [SerializeField] private AudioClip musicForMissions;
    [SerializeField] private AudioClip musicChill;
    [SerializeField] private AudioClip musicTimeOver;
    [SerializeField] private AudioClip musicGameOver;
    [SerializeField] private Slider sliderMusicVolume;

    private void Awake()
    {
        Instance = this;
        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        GeneralGameLogic.Instance.OnMissionPlaying += GeneralGameLogic_OnMissionPlaying;
        GeneralGameLogic.Instance.OnMissionCompleted += GeneralGameLogic_OnMissionCompleted;
        PlayerStats.Instance.OnPlayerDeath += PlayerStats_OnPlayerDeath;
        PlayerStats.Instance.OnPlayerRevive += PlayerStats_OnPlayerRevive;
    }

    private void PlayerStats_OnPlayerRevive(object sender, System.EventArgs e)
    {
        PlayChillMusic();
    }

    private void PlayerStats_OnPlayerDeath(object sender, System.EventArgs e)
    {
        PlayGameOverMusic();
    }

    private void GeneralGameLogic_OnMissionCompleted(object sender, System.EventArgs e)
    {
        PlayChillMusic();
    }

    private void GeneralGameLogic_OnMissionPlaying(object sender, System.EventArgs e)
    {
        PlayMusicMission();
    }

    public void ModifyMusicVolume()
    {
        audioSource.volume = sliderMusicVolume.value;
    }

    public void PlayMusicMission()
    {
        audioSource.clip = musicForMissions;
        audioSource.Play();
    }

    public void PlayChillMusic()
    {
        audioSource.clip = musicChill;
        audioSource.Play(); 
    }

    public void PlayGameOverMusic()
    {
        audioSource.clip = musicGameOver;
        audioSource.Play();
    }

    public void PlayTimeOverMusic()
    {
        audioSource.clip = musicTimeOver;
        audioSource.Play();

        Invoke("PlayChillMusic", 6);
    }

    public void StopMusic()
    {
        audioSource.Stop();
    }

}
