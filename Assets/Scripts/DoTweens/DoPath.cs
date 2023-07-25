using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class DoPath : MonoBehaviour
{
    [SerializeField] private Vector3[] paths;
    [SerializeField] private float duration;
    [SerializeField] private PathType pathType;

    // Start is called before the first frame update
    void Start()
    {
        transform.DOLocalPath(paths, duration, pathType);
    }

    
}
