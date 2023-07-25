using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ItemsToSpawnSO : ScriptableObject
{
    [SerializeField] public string nameObject;
    [SerializeField] public Transform prefab;
}
