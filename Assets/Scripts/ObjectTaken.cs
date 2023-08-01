using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ObjectTaken : MonoBehaviour
{
    [SerializeField] private ItemsToSpawnSO itemsToSpawnSO;
    public event EventHandler<OnPickedObjectEventArgs> OnPickedObject;
    public class OnPickedObjectEventArgs : EventArgs
    {
        public string objectName;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            SoundManagerScript.Instance.PlaySoundItemObtained();
            //Destroy(gameObject);
            gameObject.SetActive(false);
            OnPickedObject?.Invoke(this, new OnPickedObjectEventArgs { objectName = itemsToSpawnSO.nameObject });
            //Debug.Log("Comiste: " + itemsToSpawnSO.nameObject);
        }
    }


}
