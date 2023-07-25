using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class TextMeshColorChanger : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI tudzoneText;

    [SerializeField] private int color;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(color == 1)
        {   
            tudzoneText.color = new Color(0, 228, 253, 255);
            tudzoneText.faceColor = new Color(0, 255, 0, 255);
        }
    }
}
