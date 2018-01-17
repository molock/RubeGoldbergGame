using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour {

	private Vector3 startPos;
	private Quaternion startRot;
	private Rigidbody rb;
	private Color defultColor;

	public bool isLegal = false;
	public List<GameObject> starsList;
	public LevelConfig levelConfig;
	public Color illegalColor = Color.red;
	public bool isGrabbing = false; 
	public bool isInPlatform = false;
	
	public void ResetGame()
	{
		transform.position = startPos;
		transform.rotation = startRot;
		rb.velocity = new Vector3(0,0,0);
		isGrabbing = false;

		ResetStars();
		levelConfig.ResetScore();
	}

	void ResetStars()
	{
		foreach (GameObject star in starsList)
		{
			StarController starController = star.GetComponent<StarController>();
			starController.Reset();
		}
	}


	void Awake()
    {
        startPos = transform.position;
        startRot = transform.rotation;
        rb = GetComponent<Rigidbody>();
		defultColor = GetComponent<Renderer>().material.GetColor("_Color");
    }

	// Use this for initialization
	void Start () {
		
	}

	void OnCollisionEnter(Collision other)
	{
		// reset ball and stars
		if (other.gameObject.CompareTag("Ground"))
		{
			ResetGame();
		}
	}

	public void SetLegal()
	{
		isLegal = true;
		GetComponent<Renderer>().material.SetColor("_Color", defultColor);
		//Debug.Log("set ball to legal");
		//Debug.Log("Ball Color: " + GetComponent<Renderer>().material.GetColor("_Color").ToString());
	}

	public void SetIllegal()
    {
		isLegal = false;
		GetComponent<Renderer>().material.SetColor("_Color", illegalColor);
		//Debug.Log("set ball to illegal");
		//Debug.Log("Ball Color: " + GetComponent<Renderer>().material.GetColor("_Color").ToString());
    }

	
	// Update is called once per frame
	void Update () {
		
	}
}
