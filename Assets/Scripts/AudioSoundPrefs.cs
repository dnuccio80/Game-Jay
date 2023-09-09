using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AudioSoundPrefs : MonoBehaviour
{

    public static AudioSoundPrefs Instance { get; private set; }

    public event EventHandler OnMusicVolumeChanged;
    public event EventHandler OnSoundVolumeChanged;

    private int sound;
    private int music;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        LoadData();
        Invoke("LoadLocal", 0.1f);
    }

    private void LoadLocal()
    {
        // If we need to load something with a delay;
    }

    public void ChangeMusicVolume(float _volume)
    {
        music = (int)Mathf.Round(_volume);
        SaveData();
        OnMusicVolumeChanged?.Invoke(this, EventArgs.Empty);
    }

    public void ChangeSoundVolume(float _volume)
    {
        sound = (int)Mathf.Round(_volume);
        SaveData();
        OnSoundVolumeChanged?.Invoke(this, EventArgs.Empty);
    }

    private void SaveData()
    {
        PlayerPrefs.SetInt("sound", sound);
        PlayerPrefs.SetInt("music", music);
        
    }

    private void LoadData()
    {
        sound = PlayerPrefs.GetInt("sound");
        music = PlayerPrefs.GetInt("music");
    }

    public int GetMusicVolume()
    {
        return music;
    }

    public int GetSoundVolume()
    {
        return sound;
    }

}
