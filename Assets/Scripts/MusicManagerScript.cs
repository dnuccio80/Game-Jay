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

    private void PlayMusicMission()
    {
        audioSource.clip = musicForMissions;
        audioSource.Play();
    }

    private void PlayChillMusic()
    {
        audioSource.clip = musicChill;
        audioSource.Play();
    }

    public void PlayTimeOverMusic()
    {
        audioSource.clip = musicTimeOver;
        audioSource.Play();

        Invoke("PlayChillMusic", 6);
    }

}
