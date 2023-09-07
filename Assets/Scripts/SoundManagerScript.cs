using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{

    public static SoundManagerScript Instance { get; private set; }

    [SerializeField] private AudioClip victorySound;
    [SerializeField] private AudioClip itemObtained;
    [SerializeField] private AudioClip clickButtonSound;
    [SerializeField] private AudioClip hoverButtonSound;

    private AudioSource audioSource; 


    private void Awake()
    {
        Instance = this;
        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        GeneralGameLogic.Instance.OnMissionCompleted += GeneralGameLogic_OnMissionCompleted;
    }

    private void GeneralGameLogic_OnMissionCompleted(object sender, System.EventArgs e)
    {
        if(!GeneralGameLogic.Instance.GetIfAllMissionsCompleted()) audioSource.PlayOneShot(victorySound, 0.7f);
    }

    public void PlaySoundItemObtained()
    {
        audioSource.PlayOneShot(itemObtained, 1f);
    }

    public void PlayButtonHover()
    {
        audioSource.PlayOneShot(hoverButtonSound, .1f);
    }

    public void PlayClickButton()
    {
        audioSource.PlayOneShot(clickButtonSound, .1f);
    }
}
