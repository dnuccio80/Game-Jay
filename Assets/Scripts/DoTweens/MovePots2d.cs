using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class MovePots2d : MonoBehaviour
{

    [SerializeField] private Vector3 pointToMove;
    [SerializeField] private Image potToActive;
    private Vector3 initialPosition;

    private void Awake()
    {
        initialPosition = transform.position;
    }

    private void OnEnable()
    {
        transform.DOLocalMove(pointToMove, 2)
        .SetEase(Ease.InQuint)
        .OnComplete(() =>
        {
            transform.DOLocalMove(Vector3.zero, .5f);
            transform.gameObject.SetActive(false);
            potToActive.color = Color.white;
        });
    }


}
