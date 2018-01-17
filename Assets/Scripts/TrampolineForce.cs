using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrampolineForce : MonoBehaviour {

	public float elasticForce = 500f;
	public float forwardFore = 100f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.CompareTag("Throwable"))
		{
			other.rigidbody.AddForce(Vector3.up * elasticForce);
			//other.rigidbody.AddForce(Vector3.forward * forwardFore);
		}
	}
}
