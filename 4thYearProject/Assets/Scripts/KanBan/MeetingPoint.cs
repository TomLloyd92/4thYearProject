using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeetingPoint : MonoBehaviour
{
    public bool spotTaken = false;

    public void takeSpot()
    {
        spotTaken = true;
    }

    public void releaseSpot()
    {
        spotTaken = false;
    }

}
