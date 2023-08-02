using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LettersGameLogic : MonoBehaviour
{
    public static LettersGameLogic Instance { get; private set; }

    public event EventHandler OnAllLettersCatched;

    private int lettersCatched = 0;

    [SerializeField] private Transform aura;
    [SerializeField] private Transform[] objectsInGame;

    private void Awake()
    {
        Instance = this;
    }


    public void IncreaseLettersCatched()
    {
        lettersCatched++;

        if (lettersCatched == 7)
        {
            OnAllLettersCatched?.Invoke(this, EventArgs.Empty);
            aura.gameObject.SetActive(true);
        }
    }


    public void RestartGameStats()
    {
        lettersCatched = 0;
        aura.gameObject.SetActive(false);


        foreach (Transform obj in objectsInGame)
        {
            obj.gameObject.SetActive(true);
        }

    }
}
