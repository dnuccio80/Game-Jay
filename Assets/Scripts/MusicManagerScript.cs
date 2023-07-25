using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManagerScript : MonoBehaviour
{

    public static MusicManagerScript Instance { get; private set; }
    private AudioSource audioSource;

    [SerializeField] private AudioClip musicForMissions;
    [SerializeField] private AudioClip musicChill;


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
        audioSource.clip = musicChill;
        audioSource.Play();
    }

    private void GeneralGameLogic_OnMissionPlaying(object sender, System.EventArgs e)
    {
        audioSource.clip = musicForMissions;
        audioSource.Play();
    }

}
