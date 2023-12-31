using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitPointDamage : MonoBehaviour
{

    [SerializeField] private int damageSkill;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            gameObject.SetActive(false);

            PlayerStats.Instance.ReduceLife(damageSkill);
        }
    }


}
