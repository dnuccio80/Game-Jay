using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Move : MonoBehaviour
{

    [SerializeField] Vector3 vectorMove;
    [SerializeField] float duration;
    [SerializeField] int loops;
    public LoopType loopType;
    public Ease easeType;

    // Start is called before the first frame update
    void Start()
    {
        transform.DOMove(vectorMove, duration)
            .SetLoops(loops, loopType)
            .SetEase(easeType);
           
    }

    
}
