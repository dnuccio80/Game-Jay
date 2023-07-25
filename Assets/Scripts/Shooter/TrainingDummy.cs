using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainingDummy : BulletTarget
{

    
    [SerializeField] private Transform arrow;
    [SerializeField] private BoxCollider[] colliders;

    public override void ProjectileStashed()
    {
        life--;
        animator.SetTrigger("Hited");
        if(life <= 0)
        {
            animator.SetBool("IsDead", true);
            arrow.gameObject.SetActive(false);
            TrainingManager.Instance.DecreaseDummiesAlive();    
            foreach (BoxCollider collider in colliders)
            {
                collider.enabled = false;
            }
        }
    }
}
