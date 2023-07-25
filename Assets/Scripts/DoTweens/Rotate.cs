using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Rotate : MonoBehaviour
{
 
    void Start()
    {

        if (transform != null)
        {
            transform.DORotate(new Vector3(0.0f, 360.0f, 0.0f), 5.0f, RotateMode.FastBeyond360)
                .SetLoops(-1, LoopType.Restart)
                .SetRelative()
                .SetEase(Ease.Linear);
        }
    }

    private void OnDestroy() 
    {
        transform.DOPause();
    }
}
