using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSoundPrefs : MonoBehaviour
{

    private int sound;
    private int music;


    private void Start()
    {
        LoadData();
        Invoke("LoadLocal", 0.1f);
    }

    private void LoadLocal()
    {
        // If we need to load something with a delay;
    }

    public void ChangeMusicVolume(int _volume)
    {
        music = _volume;
        SaveData();
    }

    public void ChangeSoundVolume(int _volume)
    {
        sound = _volume;
        SaveData();
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

}
