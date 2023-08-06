using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;


public class PotionsGameLogic : MonoBehaviour
{

    public static PotionsGameLogic Instance { get; private set; }

    public event EventHandler OnAllMushroomCatched;
    public event EventHandler OnAllCoinsChatched;
    public event EventHandler OnZombieArrive;
    public event EventHandler OnRestartGame;

    private int mushroomCount = 3;
    private int coinCount = 10;
    private int potionsCounter = 0;

    [SerializeField] private TextMeshProUGUI mushroomCounter;
    [SerializeField] private TextMeshProUGUI coinCounter;
    [SerializeField] private Transform coinUI;
    [SerializeField] private Transform mushroomUI;
    [SerializeField] private GameObject aura;

    private void Awake()
    {
        Instance = this;
        mushroomCounter.text = mushroomCount.ToString();
        coinCounter.text = coinCount.ToString();
       
    }

    public void AddMushroom()
    {
        mushroomCount--;
        mushroomCounter.text = mushroomCount.ToString();
        mushroomUI.GetComponent<DoShake>().ShakeItem();
        if (mushroomCount == 0)
        {
            OnAllMushroomCatched?.Invoke(this, EventArgs.Empty);
        }

    }

    public void AddCoin()
    {
        coinCount--;
        coinCounter.text = coinCount.ToString();
        coinUI.GetComponent<DoShake>().ShakeItem();
        if(coinCount == 0)
        {
            OnAllCoinsChatched?.Invoke(this, EventArgs.Empty);
        }
    }

    public void ZombieArrivedFine()
    {
        OnZombieArrive?.Invoke(this, EventArgs.Empty);
    }

    public void AddPotion()
    {
        potionsCounter++;
        if (potionsCounter == 3)
        {
            aura.SetActive(true);
        }
    }

    public void RestartGameStats()
    {
        mushroomCount = 3;
        coinCount = 10;
        potionsCounter = 0;
        mushroomCounter.text = mushroomCount.ToString();
        coinCounter.text = coinCount.ToString();
        aura.SetActive(false);

        OnRestartGame?.Invoke(this, EventArgs.Empty);
    }
}   
