using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanController : MonoBehaviour {

	public float windForce = 2000f;

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Throwable"))
		{
			other.GetComponent<Rigidbody>().AddForce(Vector3.right * windForce);
		}
	}
}
