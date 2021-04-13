using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoCollider : MonoBehaviour
{
    [SerializeField] Canvas infoCanvas;

    public void turnOffInfo()
    {
        infoCanvas.enabled = false;
    }

    public void turnOnInfo()
    {
        infoCanvas.enabled = true;
    }

}
