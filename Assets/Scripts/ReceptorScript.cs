using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReceptorScript : MonoBehaviour
{

    [SerializeField] string objectToReceive;
    [SerializeField] Transform UIColorCircleStat;
    private bool posedInPlace = false;

    private void Start()
    {
        CubicGameLogic.Instance.OnRestartGame += CubicGameLogic_OnRestartGame;
    }

    private void CubicGameLogic_OnRestartGame(object sender, System.EventArgs e)
    {
        RestartGameStats();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Cube")
        {
            string nameObject = other.GetComponent<PickableObject>().GetNameObject();

            if (nameObject == objectToReceive)
            {
                other.transform.SetParent(this.transform);
                other.transform.localPosition = Vector3.zero;
                if(!posedInPlace) CubicGameLogic.Instance.IncreaseCoincidence();
                posedInPlace = true;
                other.GetComponent<PickableObject>().ChangeDeliveredStatus();
                UIColorCircleStat.gameObject.SetActive(true);
            } 
        }

    }

    public void RestartGameStats()
    {
        posedInPlace = false;
    }


}
