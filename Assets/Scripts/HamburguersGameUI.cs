using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HamburguersGameUI : MonoBehaviour
{
    [SerializeField] GameObject[] greenTicks;

    private void OnEnable()
    {
        foreach (GameObject tick in greenTicks)
        {
            tick.SetActive(false);
        }
    }

}
