using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using DG.Tweening;


public class PortalsGameLogic : MonoBehaviour
{
    public static PortalsGameLogic Instance { get; private set; }

    public event EventHandler onPetCatched;

    

    [SerializeField] private GameObject imagePetPlayable;
    [SerializeField] private Transform[] rabbits;

    private void Awake()
    {
        Instance = this;
        
    }

    public void OnRabbitCatched()
    {
        onPetCatched?.Invoke(this, EventArgs.Empty);
        imagePetPlayable.SetActive(true);
    }


    public void RestartGameStats()
    {
        Vector3 normalScale = new Vector3(1,1,1);

        foreach (Transform pet in rabbits)
        {
            pet.gameObject.transform.DOScale(normalScale, .1f);
        }
    }

}
