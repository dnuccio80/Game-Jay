using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{

    [SerializeField] private Button playButton;

    private void OnEnable()
    {
        playButton.Select();
    }

    private void Awake()
    {
        playButton.onClick.AddListener(() =>
        {
            if(!firstTimeiniciated.instance.GetTrainingStatus())
            {
                LoaderScript.Load(LoaderScript.Scene.Training);
            } else
            {
                
            }
        });
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quiting game");
    }

}
