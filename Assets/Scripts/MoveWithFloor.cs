using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWithFloor : MonoBehaviour
{
    private CharacterController player;

    Vector3 groundPosition;
    Vector3 lastGroundPosition;
    string groundName;
    string lastGroundName;

    private void Start()
    {
        player = GetComponent<CharacterController>();
    }

    private void Update()
    {
        if(player.isGrounded)
        {
            RaycastHit hit;

            if(Physics.SphereCast(transform.position + new Vector3(0, 1f, 0), 0.28f, -transform.up, out hit))
            {
                GameObject groundedIn = hit.collider.gameObject;

                groundName = groundedIn.name;
                groundPosition = groundedIn.transform.position;

                if(groundPosition != lastGroundPosition && groundName == lastGroundName)
                {
                    this.transform.position += groundPosition - lastGroundPosition;
                    player.enabled = false;
                    player.transform.position = this.transform.position;
                    player.enabled = true;
                }

                lastGroundName = groundName;
                lastGroundPosition = groundPosition;
            }


        }else if(!player.isGrounded)
        {
            groundName = null;
            groundPosition = Vector3.zero;
        }
    }

    private void OnDrawGizmos()
    {
        player = GetComponent<CharacterController>();
        Gizmos.DrawWireSphere(transform.position + new Vector3 (0, 1f,0), 0.28f);
    }



}
