using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftControllerInputManager : MonoBehaviour {
    public SteamVR_TrackedObject trackedObj;
    public SteamVR_Controller.Device device;

    //Teleporter
    private LineRenderer laser;
    public GameObject teleportAimerObject;
    public Vector3 teleportLocation;
    public GameObject player;
    public LayerMask laserMask;
    public float yNudgeAmount = 1f; //specific to teleportAimerObject height

	public float throwForce = 1.5f;

	// Use this for initialization
	void Start () {
        trackedObj = GetComponent<SteamVR_TrackedObject>();
        laser = GetComponentInChildren<LineRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		// int rightIndex = SteamVR_Controller.GetDeviceIndex(SteamVR_Controller.DeviceRelation.Rightmost);
        // int leftIndex = SteamVR_Controller.GetDeviceIndex(SteamVR_Controller.DeviceRelation.Leftmost);

		device = SteamVR_Controller.Input((int)trackedObj.index);

		// use only left hand controller to teleport
        if (device.GetPress(SteamVR_Controller.ButtonMask.Touchpad))
        {
            laser.gameObject.SetActive(true);
            teleportAimerObject.SetActive(true);

            laser.SetPosition(0, gameObject.transform.position);
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit, 15, laserMask))
            {
                teleportLocation = hit.point;
                laser.SetPosition(1, teleportLocation);
                //aimer position
                teleportAimerObject.transform.position = new Vector3(teleportLocation.x, teleportLocation.y + yNudgeAmount, teleportLocation.z);
            }
            else
            {
                teleportLocation = transform.forward * 15 + transform.position;
                RaycastHit groundRay;
                if (Physics.Raycast(teleportLocation, -Vector3.up, out groundRay, 17, laserMask))
                {
                    teleportLocation = groundRay.point;

                }
                laser.SetPosition(1, transform.forward * 15 + transform.position);
                //aimer position
                teleportAimerObject.transform.position = teleportLocation + new Vector3(0, yNudgeAmount, 0);

            }
        }

        if (device.GetPressUp(SteamVR_Controller.ButtonMask.Touchpad))
        {
            laser.gameObject.SetActive(false);
            teleportAimerObject.SetActive(false);
            player.transform.position = teleportLocation;
        }
	}

    void OnTriggerEnter(Collider other)
    {

    }

	void OnTriggerStay(Collider col)
    {
        if (col.gameObject.CompareTag("Throwable"))
        {
            if (device.GetPressUp(SteamVR_Controller.ButtonMask.Grip))
            {
                ThrowObject(col);
            }
            else if (device.GetPressDown(SteamVR_Controller.ButtonMask.Grip) && 
                     col.GetComponent<BallController>().isInPlatform)
            {
                GrabObject(col);
            }
        }
    }

	void GrabObject(Collider coli)
    {
        coli.transform.SetParent(gameObject.transform);
        coli.GetComponent<Rigidbody>().isKinematic = true;
        coli.GetComponent<BallController>().isGrabbing = true;
        //device.TriggerHapticPulse(2000);
    }
    void ThrowObject(Collider coli)
    {
        // anti-cheat
        BallController ball = coli.GetComponent<BallController>();
        
        if (ball.isLegal == true)
        {
            coli.GetComponent<BallController>().isGrabbing = false;
            coli.transform.SetParent(null);
            Rigidbody rigidBody = coli.GetComponent<Rigidbody>();
            rigidBody.isKinematic = false;
            rigidBody.velocity = device.velocity * throwForce;
            rigidBody.angularVelocity = device.angularVelocity;
        }
        
    }
}
