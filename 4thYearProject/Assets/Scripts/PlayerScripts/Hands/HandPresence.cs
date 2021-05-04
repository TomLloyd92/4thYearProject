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
        //New List of Devices
        List<InputDevice> devices = new List<InputDevice>();
        //Get Devices with Controller Characteristics
        InputDevices.GetDevicesWithCharacteristics(controllerCharacteristics, devices);

        //Log the name of each device connected
        foreach (var item in devices)
        {
            Debug.Log(item.name + item.characteristics);
        }

        //If there is a Device connected
        if (devices.Count > 0)
        {
            targetDevice = devices[0];
            //Assign Relative controller prefab
            GameObject prefab = controllerPrefab.Find(controller => controller.name == targetDevice.name);
            //If the prefab was assigned and not null
            if (prefab)
            {
                //Instantiate prefab
                spawnedController = Instantiate(prefab, transform);
            }
            else
            {
                //Default to oculus controller
                Debug.Log("Did not find the correct Controller, Default to Oculus Quest 2 Controller");
                spawnedController = Instantiate(controllerPrefab[0], transform);
            }


            //Assign the hand model prefab and Animator
            spawnedHandModel = Instantiate(handModelPrefab, transform);
            handAnimator = spawnedHandModel.GetComponent<Animator>();
        }

    }

    void UpdateHandAnimator()
    {
        //Try Initialize Controller if not Detected on start
        if (!targetDevice.isValid)
        {
            TryInitialize();
        }
        else
        {
            //Controller inputs
            //Check for Trigger
            if (targetDevice.TryGetFeatureValue(CommonUsages.trigger, out float triggerValue))
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
        if (showController)
        {
            //Turn off hands and turn on controller
            spawnedHandModel.SetActive(false);
            spawnedController.SetActive(true);
        }
        else
        {
            if(spawnedHandModel != null)
            {
                //Activate hands and update hand animations
                spawnedHandModel.SetActive(true);
                spawnedController.SetActive(false);
                UpdateHandAnimator();

            }

        }
    }
}
