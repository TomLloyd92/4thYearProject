using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cup : MonoBehaviour
{
    bool scored = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 eulerAngles = transform.eulerAngles;

        if (scored == false)
        {
            if(eulerAngles.x < 60 || eulerAngles.x > 125)
            {
                CupGameManager.instance.increaseCupsKnocked();
                scored = true;
            }
        }
    }
}
