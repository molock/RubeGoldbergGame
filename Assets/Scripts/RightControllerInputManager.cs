using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightControllerInputManager : MonoBehaviour {
    public SteamVR_TrackedObject trackedObj;
    public SteamVR_Controller.Device device;

    public ObjectMenuManager objectMenuManager;
    //private bool showMenu = false;

    //Swipe
    public float swipeSum;
    public float touchLast;
    public float touchCurrent;
    public float distance;
    public bool hasSwipedLeft;
    public bool hasSwipedRight;


	// Use this for initialization
	void Start () {
        trackedObj = GetComponent<SteamVR_TrackedObject>();
	}
	
	// Update is called once per frame
	void Update () {
		// int rightIndex = SteamVR_Controller.GetDeviceIndex(SteamVR_Controller.DeviceRelation.Rightmost);
        // int leftIndex = SteamVR_Controller.GetDeviceIndex(SteamVR_Controller.DeviceRelation.Leftmost);

		device = SteamVR_Controller.Input((int)trackedObj.index);

        // Right hand controller setting for object menu
        if (device.GetTouchDown(SteamVR_Controller.ButtonMask.Touchpad))
        {
            // show object menu
            objectMenuManager.ShowMenu();

            touchLast = device.GetAxis(Valve.VR.EVRButtonId.k_EButton_SteamVR_Touchpad).x;
        }

        if (device.GetTouchUp(SteamVR_Controller.ButtonMask.Touchpad))
        {
            // hide object menu
            objectMenuManager.HideMenu();
        }

        // Spawn the object from menu
        if (device.GetPressDown(SteamVR_Controller.ButtonMask.Trigger))
        {
            SpawnObject();
        }

        // track the thumb's position in touchpad
        if (device.GetTouch(SteamVR_Controller.ButtonMask.Touchpad))
        {
            touchCurrent = device.GetAxis(Valve.VR.EVRButtonId.k_EButton_SteamVR_Touchpad).x;
            distance = touchCurrent - touchLast;
            touchLast = touchCurrent;
            swipeSum += distance;
        }

        // To Switch the object by pressing down the touchpad
        if (device.GetPressDown(SteamVR_Controller.ButtonMask.Touchpad)) 
        {
            if (!hasSwipedRight)
            {
                if (swipeSum > 0.5f)
                {
                    swipeSum = 0;
                    SwipeRight();
                    hasSwipedRight = true;
                    hasSwipedLeft = false;
                }

            }

            if (!hasSwipedLeft)
            {
                if (swipeSum < -0.5f)
                {
                    swipeSum = 0;
                    SwipeLeft();
                    hasSwipedLeft = true;
                    hasSwipedRight = false;
                }
            }
        }

        if (device.GetPressUp(SteamVR_Controller.ButtonMask.Touchpad))
        {
            swipeSum = 0;
            touchCurrent = 0;
            touchLast = 0;
            hasSwipedRight = false;
            hasSwipedLeft = false;
        }

	}

    void SpawnObject()
    {
        objectMenuManager.SpawnCurrentObject();
    }

    void SwipeLeft()
    {
        objectMenuManager.MenuLeft();
        Debug.Log("SwipeLeft");
    }

    void SwipeRight()
    {
        objectMenuManager.MenuRight();
        Debug.Log("SwipeRight");
    }
}
