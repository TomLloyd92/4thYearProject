using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandPosition : MonoBehaviour
{
    public Vector3 GetPosition()
    {
        return this.gameObject.transform.position;
    }
}
