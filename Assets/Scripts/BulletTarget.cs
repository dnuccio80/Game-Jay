using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTarget : MonoBehaviour
{

    protected Animator animator;
    [SerializeField] protected int life;


    private void Awake()
    {
        animator = GetComponent<Animator>();
    }


    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.GetComponent<BulletProjectileScript>() != null)
        {
            ProjectileStashed();
        }
    }

    public virtual void ProjectileStashed()
    {

    }


}
