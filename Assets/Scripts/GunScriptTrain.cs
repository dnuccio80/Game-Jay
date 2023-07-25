using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScriptTrain : MonoBehaviour
{
    [SerializeField] private Transform gunUI;

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);

    }
}
