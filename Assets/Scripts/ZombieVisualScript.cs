using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieVisualScript : MonoBehaviour
{

    [SerializeField] Animator animator;


    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            animator.SetBool("IsTalking", true);
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            animator.SetBool("IsTalking", false);
        }
    }


}
