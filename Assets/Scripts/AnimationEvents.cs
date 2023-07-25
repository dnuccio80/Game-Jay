using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEvents : MonoBehaviour
{

    private Transform gunPrefab;


    private void Awake()
    {
        gunPrefab = transform.Find("Gun");
    }



    private void AppearGun()
    {
        gunPrefab.gameObject.SetActive(true);
    }

    private void DessappearGun()
    {
        gunPrefab.gameObject.SetActive(false);
    }


}
