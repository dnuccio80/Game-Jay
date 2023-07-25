using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFormTimeline : MonoBehaviour
{

    private Vector3 positionEndTrainingTimeline = new Vector3(427.89f, 160.08f, 622.39f);

    public void ChangePositionToEndTimeline()
    {
        transform.position = positionEndTrainingTimeline;
    }

}

    