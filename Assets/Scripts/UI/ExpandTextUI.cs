using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ExpandTextUI : MonoBehaviour
{
    Vector3 originalPositionMissionText;
    Vector3 originalPositionCompleteText;
    [SerializeField] private GameObject missionText;
    [SerializeField] private GameObject completeText;

    private float positionXMissionText = -428.87f;
    private float positionXCompleteText = 352.37f;

    private void Awake()
    {
        originalPositionMissionText = missionText.transform.position;
        originalPositionCompleteText = completeText.transform.position;
    }

    private void OnEnable()
    {
        MoveMissionText();

    }

    private void MoveMissionText()
    {
       missionText.transform.DOLocalMoveX(positionXMissionText, 1f)
            .SetEase(Ease.OutBounce)
            .SetDelay(.5f)
            .OnComplete(() =>
            {
                MoveCompleteText();
            });

    }

    private void MoveCompleteText()
    {
        completeText.transform.DOLocalMoveX(positionXCompleteText, 1f)
            .SetEase(Ease.OutBounce)
            .OnComplete(() =>
            {
                OnDesapear();
            });
    }

    private void OnDesapear()
    {
        missionText.transform.DOScale(Vector3.zero, 1f)
            .SetDelay(1f)
            .SetEase(Ease.InBounce)
            .OnComplete(() =>
            {
                missionText.transform.DORewind();
                missionText.transform.position = originalPositionMissionText;
            });
        completeText.transform.DOScale(Vector3.zero, 1f)
            .SetEase(Ease.InBounce)
            .SetDelay(1f)
            .OnComplete(() =>
            {
                completeText.transform.DORewind();
                completeText.transform.position = originalPositionCompleteText;
                gameObject.SetActive(false);
            });


        

    }

}
