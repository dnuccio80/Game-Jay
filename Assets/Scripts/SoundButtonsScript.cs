using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundButtonsScript : MonoBehaviour
{

    private AudioSource audioSource;
    [SerializeField] private AudioClip hoverButtonSound;
    [SerializeField] private AudioClip clickButtonSound;


    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void SoundButon(int soundValue)
    {
        if(soundValue == 0)
        {
            audioSource.clip = hoverButtonSound;
        } else if(soundValue == 1)
        {
            audioSource.clip = clickButtonSound;
        }

        PlaySoundButton();
    }

    private void PlaySoundButton()
    {
        audioSource.Play();
    }

}
