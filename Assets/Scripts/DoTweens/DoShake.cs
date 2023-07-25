using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DoShake : MonoBehaviour
{

    public float duration;
    public float strength;
    public int vibrato;
    public float randomness;
    private Vector3 initialPosition;

    private void Start()
    {
        initialPosition = transform.position;
    }


    public void ShakeItem()
    {
        transform.DOShakePosition(duration, strength, vibrato, randomness)
            .OnComplete(() =>
            {
                transform.position = initialPosition;
            });
    }



}
