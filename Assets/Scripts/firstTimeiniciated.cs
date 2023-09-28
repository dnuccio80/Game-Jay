using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class firstTimeiniciated : MonoBehaviour
{

    public static firstTimeiniciated instance;

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
  
}
