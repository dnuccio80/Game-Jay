using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class StartTimelineScript : MonoBehaviour
{

    [SerializeField] private PlayableDirector startTimeline;
   
    private void OnEnable()
    {
        startTimeline.Play();
    }

        
}
