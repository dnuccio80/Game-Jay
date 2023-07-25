using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class LocalMoveSimple : MonoBehaviour
{

    [SerializeField] Vector3 firstPoint;
    [SerializeField] Vector3 secondPoint;
    [SerializeField] float timeDuration;
    [SerializeField] Ease easeType;

    private void Start()
    {
        transform.DOLocalMove(firstPoint, timeDuration)
            .SetEase(easeType)
            .OnComplete(() =>
            {
                OnSecondPoint();
            });
    }


    private void OnSecondPoint()
    {
        transform.DOLocalMove(secondPoint, timeDuration)
            .SetEase(easeType)
            .OnComplete(() =>
            {
                Start();
            });
    }

}
