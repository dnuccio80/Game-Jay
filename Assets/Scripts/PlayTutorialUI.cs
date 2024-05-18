using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayTutorialUI : MonoBehaviour
{

    [SerializeField] private MainMenu mainMenu;
    [SerializeField] private Button playTutorialButton;
    [SerializeField] private Button skipTutorialButton;

    private void Start()
    {
        mainMenu.OnPlayButtonPressed += MainMenu_OnPlayButtonPressed;
        Hide();
    }

    private void MainMenu_OnPlayButtonPressed(object sender, System.EventArgs e)
    {
        Show();
    }
    private void Show()
    {
        gameObject.SetActive(true);
        playTutorialButton.Select();
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }

}
