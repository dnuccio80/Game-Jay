using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MovingRabbit : MonoBehaviour
{

    [SerializeField] private float xPosition;
    [SerializeField] private float duration;


    void Start()
    {
        transform.DOLocalMoveX(xPosition, duration)
            .SetEase(Ease.Linear)
            .SetLoops(-1, LoopType.Yoyo);   
            
    }


   
}
