using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IncrementValueUIBarStats : MonoBehaviour
{

    [SerializeField] private Image colorStat;
    private float fillAmount = 0f;

    private void OnEnable()
    {
        colorStat.fillAmount = 0f;
    }

    private void Start()
    {
        CubicGameLogic.Instance.OnRestartGame += CubicGameLogic_OnRestartGame;
    }

    private void CubicGameLogic_OnRestartGame(object sender, System.EventArgs e)
    {
        fillAmount = 0f;
        gameObject.SetActive(false);
    }

    void Update()
    {
        if(fillAmount < 0.25f)
        {
            fillAmount += 0.005f;
            colorStat.fillAmount = fillAmount;
        }
    }
}
