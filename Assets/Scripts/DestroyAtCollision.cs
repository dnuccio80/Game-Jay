using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DestroyAtCollision : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI tudzoneLetter;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //Destroy(gameObject);
            gameObject.SetActive(false);
            SoundManagerScript.Instance.PlaySoundItemObtained();
            tudzoneLetter.color = new Color(0, 228, 253, 255);
            tudzoneLetter.faceColor = new Color(0, 255, 0, 255);
            LettersGameLogic.Instance.IncreaseLettersCatched();
        }

        
    }

    




}
