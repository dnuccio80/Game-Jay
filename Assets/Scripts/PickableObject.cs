using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;
using Cinemachine;
using System;

public class PickableObject : MonoBehaviour
{

    public static PickableObject Instance { get; private set; }


    [SerializeField] private Transform PlayerInteractionZone;
    [SerializeField] private CinemachineVirtualCamera pickableGameCamera;
    [SerializeField] private Transform interactUI;
    [SerializeField] private Transform cubicGameParent;
    private Vector3 initialPosition;

    public event EventHandler OnPickedObject;
    public event EventHandler OnDropedObject;

    Rigidbody myRB;
    public bool canInteract = false;
    bool isPicked = false;
    [SerializeField] private string nameObject;
    private bool isDeliveredRight = false;
    private bool showInteractUI = true;

    private void Awake()
    {
        myRB = GetComponent<Rigidbody>();
        Instance = this;
        initialPosition = transform.position;
    }


    private void Start()
    {
        StarterAssets.StarterAssetsInputs.Instance.OnInteractButtonPressed += StarterAssets_OnInteractButtonPressed;
        CubicGameLogic.Instance.OnRestartGame += CubicGameLogic_OnRestartGame;
        PlayerStats.Instance.OnPlayerDeath += PlayerStats_OnPlayerDeath;
    }

    

    private void CubicGameLogic_OnRestartGame(object sender, EventArgs e)
    {
        transform.SetParent(cubicGameParent);
        transform.position = initialPosition;
        RestartDeliveredStatus();
    }

    private void StarterAssets_OnInteractButtonPressed(object sender, System.EventArgs e)
    {
        if(canInteract && !isPicked && !StarterAssets.StarterAssetsInputs.Instance.GetObjectStatus() && !isDeliveredRight)
        {
            AnimationDelegates.Instance.PickUpObject();
            StartCoroutine("PickObject");
            canInteract = false;
            CubicGameLogic.Instance.hasAnObject = true;
            pickableGameCamera.gameObject.SetActive(true);
            
        }
        else if(isPicked)
        {
            AnimationDelegates.Instance.DropObject();
            myRB.useGravity = true;
            myRB.isKinematic = false;
            gameObject.transform.SetParent(null);
            isPicked = false;
            StarterAssets.StarterAssetsInputs.Instance.ChangeObjectStatus(false, 8f, true);
            StopCoroutine("DropObject");
            StopCoroutine("DropObject");
            canInteract = true;
            pickableGameCamera.gameObject.SetActive(false);
            CubicGameLogic.Instance.hasAnObject = false;
            
        }
    }

    private void PlayerStats_OnPlayerDeath(object sender, EventArgs e)
    {
        myRB.useGravity = true;
        myRB.isKinematic = false;
        gameObject.transform.SetParent(null);
        isPicked = false;
        CubicGameLogic.Instance.hasAnObject = false;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "InteractionZone")
        {
            canInteract = true;
            if(showInteractUI) interactUI.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "InteractionZone")
        {
            canInteract = false;
            interactUI.gameObject.SetActive(false);
        }
    }

    private IEnumerator PickObject ()
    {
        yield return new WaitForSeconds(0.9f);
        myRB.isKinematic = true;
        myRB.useGravity = false;
        OnPickedObject?.Invoke(this, EventArgs.Empty);
        gameObject.transform.SetParent(PlayerInteractionZone);
        transform.localPosition = Vector3.zero;
        isPicked = true;
        StarterAssets.StarterAssetsInputs.Instance.ChangeObjectStatus(true, 4f, false);
        StopCoroutine("PickObject");
    }

    public string GetNameObject()
    {
        return nameObject;
    }

    public void ChangeDeliveredStatus()
    {
        isDeliveredRight = true;
        showInteractUI = false;
        canInteract = false;
    }

    public void RestartDeliveredStatus()
    {
        isDeliveredRight = false;
        showInteractUI = true;
        canInteract = false;
    }

}
