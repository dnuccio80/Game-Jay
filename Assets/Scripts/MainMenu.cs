using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
using System;

public class MainMenu : MonoBehaviour
{
    public event EventHandler OnPlayButtonPressed;

    [SerializeField] private Button playButton;

    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider soundSlider;
    [SerializeField] private AudioSource musicSource;

    private void OnEnable()
    {
        playButton.Select();
    }

    private void Awake()
    {
        playButton.onClick.AddListener(() =>
        {
            LoaderScript.Load(LoaderScript.Scene.Training, true);
        });
    }

    private void Start()
    {
       musicSource.volume = PlayerPrefs.GetInt("music")/100f;
       musicSlider.value = PlayerPrefs.GetInt("music");
       AudioSoundPrefs.Instance.OnMusicVolumeChanged += AudioSoundPrefs_OnMusicVolumeChanged;
    }

    

    private void AudioSoundPrefs_OnMusicVolumeChanged(object sender, System.EventArgs e)
    {
        musicSource.volume = PlayerPrefs.GetInt("music") / 100f;
    }

    public void QuitGame()
    {
        Application.Quit();
    }


    private void OnDestroy()
    {
        AudioSoundPrefs.Instance.OnMusicVolumeChanged -= AudioSoundPrefs_OnMusicVolumeChanged;
    }
}
