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
        Debug.Log(PlayerPrefs.GetInt("FirstTime"));
    }

    public void PlayGame()
    {
        if(!firstTimeiniciated.instance.GetTrainingStatus())
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1, LoadSceneMode.Single);
            SceneManager.LoadSceneAsync("Training", LoadSceneMode.Additive);
            Debug.Log("Primera vez que iniciamos");
        } else
        {
            Debug.Log("Segunda vez que iniciamos");
        }

      
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quiting game");
    }

}
