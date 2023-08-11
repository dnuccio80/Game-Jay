using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{

    [SerializeField] private Transform optionsMenu;
    [SerializeField] private Button playButton;

    private void OnEnable()
    {
        playButton.Select();
    }

    public void OpenOptionsMenu()
    {
        optionsMenu.gameObject.SetActive(true);
    }

    public void CloseOptionsMenu()
    {
        optionsMenu.gameObject.SetActive(false);
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quiting game");
    }

}
