using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class JumpingRabb : MonoBehaviour
{

    [SerializeField] private float yPosition;
    [SerializeField] private float duration;
    [SerializeField] private Ease easeType;

    private void Start()
    {
        transform.DOLocalMoveY(yPosition, duration)
            .SetLoops(-1, LoopType.Yoyo)
            .SetEase(easeType);
    }
        

}
