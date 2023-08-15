using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Playables;

public class TrainingManager : MonoBehaviour
{
    public static TrainingManager Instance { get; private set; }

    [SerializeField] private Transform[] trainingDummies;
    [SerializeField] private PlayableDirector endTrainingTimeline; 

    private int dummiesAlive = 0;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()    
    {
        foreach(Transform Dummies in trainingDummies)
        {
            dummiesAlive++;
        }
    }

    public void DecreaseDummiesAlive()
    {
        dummiesAlive--;

        if(dummiesAlive == 0)
        {
            endTrainingTimeline.Play();
            firstTimeiniciated.instance.ChangeTrainingStatus();
        }
    }


}
