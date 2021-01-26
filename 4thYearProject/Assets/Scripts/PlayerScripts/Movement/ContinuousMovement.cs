using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;


public class ContinuousMovement : MonoBehaviour
{
    //Character Speed
    public float speed = 1;
    //Input Node
    public XRNode inputSource;
    
    //Axis used for controller
    private Vector2 inputAxis;
    //Character controller
    private CharacterController character;
    //Rig
    private XRRig rig;

    // Start is called before the first frame update
    void Start()
    {
        //Get Rig Component
        rig = GetComponent<XRRig>();
        //Get the character component
        character = GetComponent<CharacterController>();

    }

    // Update is called once per frame
    void Update()
    {
        //Get device inserted into Node
        InputDevice device = InputDevices.GetDeviceAtXRNode(inputSource);
        //Analog stick determines 2D Axis
        device.TryGetFeatureValue(CommonUsages.primary2DAxis, out inputAxis);
    }

    private void FixedUpdate()
    {
        //Have movement face direction
        Quaternion headRotation = Quaternion.Euler(0, rig.cameraGameObject.transform.eulerAngles.y, 0);
        //Get Direction from axis movement
        Vector3 direction = headRotation *  new Vector3(inputAxis.x, 0, inputAxis.y);
        //Move character with the axis vector
        character.Move(direction * Time.deltaTime * speed);
    }
}
