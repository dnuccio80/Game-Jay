using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeTime : MonoBehaviour
{

    [SerializeField] private float lifeTime;


    void Start()
    {
        Invoke("DestroyObject", lifeTime);
    }

    private void DestroyObject()
    {
        Destroy(gameObject);
    }
    
}
