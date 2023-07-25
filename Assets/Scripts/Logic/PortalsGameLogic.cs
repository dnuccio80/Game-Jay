using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PortalsGameLogic : MonoBehaviour
{
    public static PortalsGameLogic Instance { get; private set; }

    public event EventHandler onPetCatched;

    private bool miniGameInProgress = false;
    
    [SerializeField] private GameObject imagePetPlayable;

    private void Awake()
    {
        Instance = this;
    }

    public void OnRabbitCatched()
    {
        onPetCatched?.Invoke(this, EventArgs.Empty);
        imagePetPlayable.SetActive(true);
    }

   public bool GetMiniGameStatus()
    {
        return miniGameInProgress;
    }

    public void ChangeMiniGameStatus(bool _newStatus)
    {
        miniGameInProgress = _newStatus;
    }

}
