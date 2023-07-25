using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationDelegates : MonoBehaviour
{

    public static AnimationDelegates Instance { get; private set; }

    private Animator animator;

    private void Awake()
    {
        Instance = this;
        animator = GetComponent<Animator>();
    }

    public void PickUpObject()
    {
        animator.SetTrigger("TakeObject");
    }

    public void DropObject()
    {
        animator.SetTrigger("DropObject");
    }

    public void PunchObject()
    {
        animator.SetTrigger("Punch");
    }

}
