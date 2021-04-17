using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowerScript : MonoBehaviour
{
    [SerializeField] GameObject tiedObject;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (tiedObject != null)
        { 
            transform.position = tiedObject.transform.position;
            Vector3 euler1 = tiedObject.transform.eulerAngles;
            transform.rotation = Quaternion.Euler(euler1.x , euler1.y, euler1.z);
        }
    }
}
