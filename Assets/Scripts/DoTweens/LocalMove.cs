using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class LocalMove : MonoBehaviour
{

    [SerializeField] Transform lookAt;
    [SerializeField] Transform lookAt2;
    [SerializeField] Vector3 point1;
    [SerializeField] Vector3 point2;
    [SerializeField] float duration;
    [SerializeField] int loopsQuant;
    [SerializeField] LoopType loopType;
    [SerializeField] Ease easeType;

    // Start is called before the first frame update
    void Start()
    {
        transform.LookAt(new Vector3(lookAt.position.x, transform.position.y, lookAt.position.z));
        transform.DOLocalMoveX(point1.x, duration)
            .SetLoops(loopsQuant, loopType)
            .SetEase(easeType)
            .OnComplete(() =>
            {
                MoveToOther();
            });
    }
   

    private void MoveToOther()
    {
        transform.LookAt(new Vector3(lookAt2.position.x, transform.position.y, lookAt2.position.z));
        transform.DOLocalMoveX(point2.x, duration)
            .OnComplete(() =>
            {
                Start();
            })
             
            ;
    }

    private void OnDestroy()
    {
        transform.DOKill();
    }
}
