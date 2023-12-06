using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class GameStatus : MonoBehaviour {

	// Config Params
	[Range(0.1f, 10f)] [SerializeField] float gameSpeed = 1f;
	[SerializeField] int pointsPerBlockDestroyed = 80;
	[SerializeField] TextMeshProUGUI scoreText;
	// state variables
	[SerializeField] int currentScore = 0;


	public void AddToScore()
    {
		currentScore += pointsPerBlockDestroyed;
		UpdateScore();
	}
	// Use this for initialization
	void Start () 
	{
		UpdateScore();
	}

	private void UpdateScore()
    {
		scoreText.SetText(currentScore.ToString());

	}

	// Update is called once per frame
	void Update () {
		Time.timeScale = gameSpeed;
	}
}
