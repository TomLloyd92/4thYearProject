using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
public class HandPresence : MonoBehaviour
{
    public bool showController = false;

    public InputDeviceCharacteristics controllerCharacteristics;
    public List<GameObject> controllerPrefab;
    public GameObject handModelPrefab;

    private InputDevice targetDevice;
    private GameObject spawnedController;
    private GameObject spawnedHandModel;
    private Animator handAnimator;



    // Start is called before the first frame update
    void Start()
    {
        //Initialize Controllers
        TryInitialize();
      
    }

    void TryInitialize()
    {
        List<InputDevice> devices = new List<InputDevice>();
        //Get Devices with Controller Characteristics
        InputDevices.GetDevicesWithCharacteristics(controllerCharacteristics, devices);

        foreach (var item in devices)
        {
            Debug.Log(item.name + item.characteristics);
        }

        if (devices.Count > 0)
        {
            targetDevice = devices[0];
            GameObject prefab = controllerPrefab.Find(controller => controller.name == targetDevice.name);
            if (prefab)
            {
                spawnedController = Instantiate(prefab, transform);
            }
            else
            {
                Debug.Log("Did not find the correct Controller, Default to Oculus Quest 2 Controller");
                spawnedController = Instantiate(controllerPrefab[0], transform);
            }

            spawnedHandModel = Instantiate(handModelPrefab, transform);
            handAnimator = spawnedHandModel.GetComponent<Animator>();
        }

    }    

    void UpdateHandAnimator()
    {
        //Try Initialize Controller if not Detected on start
        if(!targetDevice.isValid)
        {
            TryInitialize();
        }
        else
        {
            //Controller inputs
            //Check for Trigger
            if(targetDevice.TryGetFeatureValue(CommonUsages.trigger, out float triggerValue))
            {
                handAnimator.SetFloat("Trigger", triggerValue);
            }
            else
            {
                handAnimator.SetFloat("Trigger", 0);
            }
            //Check for Grip
            if (targetDevice.TryGetFeatureValue(CommonUsages.grip, out float gripValue))
            {
                handAnimator.SetFloat("Grip", gripValue);
            }
            else
            {
                handAnimator.SetFloat("Grip", 0);
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        if(showController)
        {
            spawnedHandModel.SetActive(false);
            spawnedController.SetActive(true);
        }
        else
        {
            spawnedHandModel.SetActive(true);
            spawnedController.SetActive(false);
            UpdateHandAnimator();
        }

        /*
        //A button
        targetDevice.TryGetFeatureValue(CommonUsages.primaryButton, out bool primaryButtonValue);
        if(primaryButtonValue)
        {
            Debug.Log("Pressing primary button");
        }

        //Trigger
        targetDevice.TryGetFeatureValue(CommonUsages.trigger, out float triggerValue);
        if(triggerValue > 0.1f)
        {
            Debug.Log("Trigger pulled: " + triggerValue);
        }

        //JoyStick
        targetDevice.TryGetFeatureValue(CommonUsages.primary2DAxis, out Vector2 primary2DAxisValue);
        if(primary2DAxisValue != Vector2.zero)
        {
            Debug.Log("TouchPad: " + primary2DAxisValue);
        }
        */



    }
}
