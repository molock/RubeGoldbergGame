using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelConfig : MonoBehaviour {

	private int currentScore = 0;
	public bool hasGetAllStars = false;
	public int winScore = 2;
	//public Text scoreText;
	public string nextScene;

	// Use this for initialization
	void Start () 
	{
		//scoreText.text = currentScore.ToString() + "/"  + winScore.ToString();
	}
	
	// Update is called once per frame
	void Update () {
		//scoreText.text = currentScore.ToString() + "/" + winScore.ToString();

		if (currentScore >= winScore)
        {
            hasGetAllStars = true;
        }

	}

	// when ball touch the goal, win the game, transfer to another level

	// reset the ball and stars
	public void ResetScore()
	{
		currentScore = 0;
	}

	public void AddScore(int score)
	{
		currentScore += score;
	}


}
