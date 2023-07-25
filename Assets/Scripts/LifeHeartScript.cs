using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeHeartScript : MonoBehaviour
{

    [SerializeField] private AudioClip lifeAudio;


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            if(!PlayerStats.Instance.GetIfLifeIsFull())
            {
                PlayerStats.Instance.IncrementLife(30);
                Destroy(gameObject);
                AudioSource.PlayClipAtPoint(lifeAudio, transform.position);
            }
           
        }
    }


}
