using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApprearObjectOnTaken : MonoBehaviour
{

    [SerializeField] private GameObject auraToAppear;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            auraToAppear.SetActive(true);
        }
    }



}
