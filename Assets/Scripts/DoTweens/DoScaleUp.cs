using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class DoScaleUp : MonoBehaviour
{

    private void OnEnable()
    {

        transform.DOScale(new Vector3(2.485241f, 8.180038f, 17.49465f), 0.4f)
            .SetEase(Ease.InExpo);


    }
}
