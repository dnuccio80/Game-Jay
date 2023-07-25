using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletProjectileScript : MonoBehaviour
{

    private Rigidbody bulletRigidBody;
    [SerializeField] private float speed;
    [SerializeField] private Transform vfxHitGreen;
    [SerializeField] private Transform vfxHitRed;
    [SerializeField] private AudioClip explosionBullet;


    private void Awake()
    {
        bulletRigidBody = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        bulletRigidBody.velocity = transform.forward * speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        AudioSource.PlayClipAtPoint(explosionBullet, transform.position, 1f);
        if(other.GetComponent<BulletTarget>() != null)
        {
            //Hit Target
            Instantiate(vfxHitGreen, transform.position, Quaternion.identity);
        } else
        {
            //Hit something else
            Instantiate(vfxHitRed, transform.position, Quaternion.identity);
        }

        Destroy(gameObject);
    }
}
