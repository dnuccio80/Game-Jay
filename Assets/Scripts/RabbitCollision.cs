using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RabbitCollision : MonoBehaviour
{

    [SerializeField] private Transform portal;
    private PortalScript portalScript;

   
    private void Awake()
    {
        portalScript = portal.GetComponent<PortalScript>();
    }

    private void Start()
    {
        MagicianMission.Instance.OnMagicianMissionRestart += MagicianMission_OnMagicianMissionRestart;
    }

    private void MagicianMission_OnMagicianMissionRestart(object sender, System.EventArgs e)
    {
        RestartGameStats();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            portal.gameObject.SetActive(true);
        }
    }

    public void RestartGameStats()
    {
        portal.gameObject.SetActive(false);
        portalScript.RestartGameStats();
    }
}
