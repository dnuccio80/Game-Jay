using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HamburguersGameLogic : MonoBehaviour
{

    public static HamburguersGameLogic Instance { get; private set; }


    private GameObject[] objectsToTake;
    private const string HAMBURGUER = "Burguer";
    private const string DRINK_BOTTLE = "Drink Bottle";
    [SerializeField] private TextMeshProUGUI hamburguersCantTextUI;
    [SerializeField] private TextMeshProUGUI bottlesCantTextUI;
    [SerializeField] private GameObject aura;
    [SerializeField] private Transform[] objectsInGame;
    private int cantBurguers = 15;
    private int cantBottles = 10;

    private void Awake()
    {
        Instance = this;
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

        } else if (e.objectName == DRINK_BOTTLE)
        {
            cantBottles--;
            bottlesCantTextUI.text = cantBottles.ToString();
        }

        if (cantBurguers == 0 && cantBottles == 0) aura.SetActive(true);
    }


    public void RestartGameStats()
    {
        cantBurguers = 15;
        cantBottles = 10;
        hamburguersCantTextUI.text = cantBurguers.ToString();
        bottlesCantTextUI.text = cantBottles.ToString();


        foreach (Transform obj in objectsInGame)
        {
            obj.gameObject.SetActive(true);
        }
    }
}
