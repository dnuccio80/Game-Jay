using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HamburguersGameLogic : MonoBehaviour
{

    private GameObject[] objectsToTake;
    private const string HAMBURGUER = "Burguer";
    private const string DRINK_BOTTLE = "Drink Bottle";
    [SerializeField] private TextMeshProUGUI hamburguersCantTextUI;
    [SerializeField] private TextMeshProUGUI bottlesCantTextUI;
    [SerializeField] private GameObject greenTickHamburguer;
    [SerializeField] private GameObject greenTickBottle;
    [SerializeField] private GameObject aura;
    private int cantBurguers = 15;
    private int cantBottles = 10;

    private void Awake()
    {
        hamburguersCantTextUI.text = cantBurguers.ToString();
        bottlesCantTextUI.text = cantBottles.ToString();

        objectsToTake = GameObject.FindGameObjectsWithTag("ObjectToTake");

        foreach(GameObject takedObject in  objectsToTake)
        {
            takedObject.GetComponent<ObjectTaken>().OnPickedObject += ObjectTaken_OnPickedObject; 
        }


    }

    private void ObjectTaken_OnPickedObject(object sender, ObjectTaken.OnPickedObjectEventArgs e)
    {

        if(e.objectName == HAMBURGUER)
        {
            cantBurguers--;
            hamburguersCantTextUI.text = cantBurguers.ToString();
            if (cantBurguers == 0) greenTickHamburguer.SetActive(true);

        } else if (e.objectName == DRINK_BOTTLE)
        {
            cantBottles--;
            bottlesCantTextUI.text = cantBottles.ToString();
            if (cantBottles == 0) greenTickBottle.SetActive(true);
        }

        if (cantBurguers == 0 && cantBottles == 0) aura.SetActive(true);
    }


}
