using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class OpenDoorsScript : MonoBehaviour
{

    [SerializeField] private GameObject leftDoor;
    [SerializeField] private GameObject rightDoor;


    private void OnEnable()
    {
        CubicGameLogic.Instance.OnAllCubicPosicioned += CubicGameLogic_OnAllCubicPosicioned;
        CubicGameLogic.Instance.OnRestartGame += Instance_OnRestartGame;
    }

    private void Instance_OnRestartGame(object sender, System.EventArgs e)
    {
        leftDoor.transform.DORotate(new Vector3(0f, 0f, 0), .5f);
        rightDoor.transform.DORotate(new Vector3(0f, 0f, 0), .5f);
    }

    private void CubicGameLogic_OnAllCubicPosicioned(object sender, System.EventArgs e)
    {
        leftDoor.transform.DORotate(new Vector3(0f, 90f, 0), 3);
        rightDoor.transform.DORotate(new Vector3(0f, -90f, 0), 3);
    }   
}
  