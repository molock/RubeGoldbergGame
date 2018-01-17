using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarController : MonoBehaviour {

	public int score = 1;
	public LevelConfig levelConfig;

	public void Reset()
	{
		gameObject.SetActive(true);
	}


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Throwable"))
		{
			//Debug.Log("Star has been hit!");
			levelConfig.AddScore(score);
            gameObject.SetActive(false);
		}
		
	}
}
