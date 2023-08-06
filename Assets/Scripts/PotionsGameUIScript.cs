using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PotionsGameUIScript : MonoBehaviour
{

    [SerializeField] private Image[] potionsUI;
    [SerializeField] private Transform coinSection;
    [SerializeField] private Transform mushRoomSection;

    // Start is called before the first frame update
    void Start()
    {
        PotionsGameLogic.Instance.OnRestartGame += PotionsGameLogic_OnRestartGame;
    }

    private void PotionsGameLogic_OnRestartGame(object sender, System.EventArgs e)
    {
        foreach (Image potion in potionsUI)
        {
            potion.color = Color.black;
        }

        coinSection.gameObject.SetActive(false);
        mushRoomSection.gameObject.SetActive(false);

        gameObject.SetActive(false);
    }

}
