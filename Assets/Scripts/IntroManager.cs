using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IntroManager : MonoBehaviour
{

    [SerializeField] private Button optionsUIBackButton;
    [SerializeField] private Button politicsBackButton;
    [SerializeField] private Button helpBackButton;
    [SerializeField] private Button creditsBackButton;


    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(optionsUIBackButton.isActiveAndEnabled)
            {
                optionsUIBackButton.onClick.Invoke();
            } else if (politicsBackButton.isActiveAndEnabled)
            {
                politicsBackButton.onClick.Invoke();
            } else if( helpBackButton.isActiveAndEnabled)
            {
                helpBackButton.onClick.Invoke();
            } else if(creditsBackButton.isActiveAndEnabled)
            {
                creditsBackButton.onClick.Invoke();
            }
        }
    }

}
