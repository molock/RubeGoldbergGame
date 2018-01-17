using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallLegalChecker : MonoBehaviour {

	
	// to check if the ball is in the legal area
	void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Throwable"))
        {
            other.GetComponent<BallController>().SetLegal();
            other.GetComponent<BallController>().isInPlatform = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        
        if (other.gameObject.CompareTag("Throwable"))
        {
            other.GetComponent<BallController>().isInPlatform = false;
            
            if (other.GetComponent<BallController>().isGrabbing == true)
            {
                other.GetComponent<BallController>().SetIllegal();
            }
            
        }

    }
}
