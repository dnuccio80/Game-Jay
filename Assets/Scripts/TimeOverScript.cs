using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TimeOverScript : MonoBehaviour
{

    private Animator animator;

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
    }


    private void OnEnable()
    {
        animator.SetTrigger("Fade");
        StartCoroutine("DisableTimeOver");
    }



    IEnumerator DisableTimeOver()
    {
        yield return new WaitForSeconds(5f);
        transform.gameObject.SetActive(false);
    }
}
