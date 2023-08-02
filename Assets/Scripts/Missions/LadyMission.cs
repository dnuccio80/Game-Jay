using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;


public class LadyMission : ExtraPlayerMission
{

    [SerializeField] GameObject lettersGame;
    [SerializeField] GameObject lettersGameUI;
    [SerializeField] TextMeshProUGUI[] lettersUI;

    public override void StartMission()
    {
        lettersGame.SetActive(true);
        lettersGameUI.SetActive(true);
    }

    public override void RestartGame()
    {
        if (GeneralGameLogic.Instance.GetMissionNumber() == _numberMission)
        {
            lettersGame.SetActive(false);
            lettersGameUI.SetActive(false);
            exclamationSign.gameObject.SetActive(true);

            LettersGameLogic.Instance.RestartGameStats();

            foreach (TextMeshProUGUI letter in lettersUI)
            {
                letter.color = new Color(0, 0, 0, 157);
                letter.faceColor = new Color(0, 0, 0, 157);
            }


        }
    }




}
