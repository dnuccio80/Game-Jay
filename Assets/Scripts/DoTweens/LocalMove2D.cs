using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class LocalMove2D : MonoBehaviour
{

    [SerializeField] private Ease easeType;
    private Vector3 initialPosition;

    private void Awake()
    {
        initialPosition = transform.position;
    }

    private void OnEnable()
    {
       
        transform.DOLocalMove(new Vector3(562.9f, 448.42f, 0), 2)
          .SetEase(easeType)
          .SetLoops(1, LoopType.Restart)
          .OnComplete(() =>
             {
                transform.position = initialPosition;
                gameObject.SetActive(false);
             });
         
    }

}
