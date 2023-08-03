using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PortalScript : MonoBehaviour
{

    [SerializeField] GameObject portalPartner;
    [SerializeField]  Vector3 offset;
    [SerializeField] private bool canTraslatePlayer;
    private bool catched = false;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player" && canTraslatePlayer)
        {
            other.enabled = false;
            other.transform.position = portalPartner.transform.position + offset;
            other.enabled = true;
        } else if(other.gameObject.tag == "PetInnerCollider")
        {
            other.gameObject.transform.DOScale(Vector3.zero, 0.4f)
                .SetEase(Ease.InCirc);
            if (!catched)
            {
                PortalsGameLogic.Instance.OnRabbitCatched();
                catched = true;
            }
            Invoke("ScaleToZero", 1);
            
        }
    }


    private void ScaleToZero()
    {
        transform.DOScale(Vector3.zero, 0.4f)
                .SetEase(Ease.InCirc);
    } 

    public void RestartGameStats()
    {
        if(!canTraslatePlayer) {
            catched = false;
        }
    }

}
