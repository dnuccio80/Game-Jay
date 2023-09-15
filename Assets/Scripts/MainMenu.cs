using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{

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
            LoaderScript.Load(LoaderScript.Scene.Training);

            //if(!firstTimeiniciated.instance.GetTrainingStatus())
            //{
            //    LoaderScript.Load(LoaderScript.Scene.Training);
            //} else if(firstTimeiniciated.instance.GetTrainingStatus())
            //{
            //    LoaderScript.Load(LoaderScript.Scene.Level1Game);
            //}
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
        Debug.Log("Quiting game");
    }


    private void OnDestroy()
    {
        AudioSoundPrefs.Instance.OnMusicVolumeChanged -= AudioSoundPrefs_OnMusicVolumeChanged;
    }
}
