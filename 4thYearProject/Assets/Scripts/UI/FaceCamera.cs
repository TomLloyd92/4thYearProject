using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceCamera : MonoBehaviour
{
    private Transform mainCamera;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        //Rotate to player
        //transform.LookAt(transform.position + mainCamera.rotation * Vector3.forward,
        //    mainCamera.rotation * Vector3.up);


            Quaternion r1 = Quaternion.LookRotation(transform.position - mainCamera.transform.position, Vector3.up);
            Vector3 euler2 = transform.eulerAngles;
            transform.rotation = Quaternion.Euler(euler2.x, r1.eulerAngles.y, euler2.z);


    }
}
