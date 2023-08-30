using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{

    [SerializeField] private Button playButton;

    [Header("Texts Modificables")]
    [SerializeField] private TextMeshProUGUI musicVolumeText;
    [SerializeField] private TextMeshProUGUI soundVolumeText;
    [SerializeField] private TextMeshProUGUI languageText;

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
            } else if(firstTimeiniciated.instance.GetTrainingStatus())
            {
                LoaderScript.Load(LoaderScript.Scene.Level1Game);
            }
        });
    }

    public void HandleInputLanguage(int val)
    {

        if(val == 0)
        {
            musicVolumeText.text = "MUSIC VOLUME";
            soundVolumeText.text = "SOUND VOLUME";
            languageText.text = "LANGUAGE";
        }
        if (val == 1)
        {
            musicVolumeText.text = "VOLUMEN DE MUSICA";
            soundVolumeText.text = "VOLUMEN DE SONIDO";
            languageText.text = "LENGUAJE";
        }
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quiting game");
    }

}
