using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookMouse : MonoBehaviour
{

    //private void Start()
    //{
    //    StarterAssets.StarterAssetsInputs.Instance.OnInteractAlternatePressed += StarterAssets_OnInteractAlternatePressed;
    //}

    //private void StarterAssets_OnInteractAlternatePressed(object sender, System.EventArgs e)
    //{
    //    UnlockMouse();
    //}

    public void LockMouse()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void UnlockMouse()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }


}
