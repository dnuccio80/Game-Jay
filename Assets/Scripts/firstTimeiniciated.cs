using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class firstTimeiniciated : MonoBehaviour
{

    public static firstTimeiniciated instance;

    private bool trainingAlreadyDone = false;

    private void Awake()
    {
        if(firstTimeiniciated.instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        } else
        {
            Destroy(gameObject);
        }
    }

    public bool GetTrainingStatus()
    {
        return trainingAlreadyDone;
    }

    public void ChangeTrainingStatus()
    {
        trainingAlreadyDone = true;
    }
   
}
