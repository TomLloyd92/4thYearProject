using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class LocomotionController : MonoBehaviour
{
    public XRController rightTeleportRay;
    public InputHelpers.Button teleportActivationButton;
    public float activationThreshhold = 0.1f;

    private XRRayInteractor rightRayInteractor;

    public bool enableTeleport { get; set; } = true;


 void Start()
    {
        if (rightTeleportRay)
            rightRayInteractor = rightTeleportRay.gameObject.GetComponent<XRRayInteractor>();
    }

    // Update is called once per frame
    void Update()
    {
        //
        if(rightTeleportRay)
        {
            //rightTeleportRay.gameObject.SetActive(CheckIfActivated(rightTeleportRay));

           rightRayInteractor.allowSelect = CheckIfActivated(rightTeleportRay);
           rightTeleportRay.gameObject.SetActive(enableTeleport && CheckIfActivated( rightTeleportRay));
        }
    }

    public bool CheckIfActivated(XRController controller)
    {
        InputHelpers.IsPressed(controller.inputDevice, teleportActivationButton, out bool isActivated, activationThreshhold);
        return isActivated;
    }
}
