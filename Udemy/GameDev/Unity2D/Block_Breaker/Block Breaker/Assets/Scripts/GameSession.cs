using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class GameSession : MonoBehaviour {

	// Config Params
	[Range(0.1f, 10f)] [SerializeField] float gameSpeed = 1f;
	[SerializeField] int pointsPerBlockDestroyed = 80;
	// state variables
	[SerializeField] int currentScore = 0;

	
	[SerializeField]  TextMeshProUGUI scoreText;
	private void Awake()
    {
		int gameStatusCount = FindObjectsOfType<GameSession>().Length;
		if (gameStatusCount>1)
        {
			gameObject.SetActive(false);
			Destroy(gameObject);
        }
        else
        {
			DontDestroyOnLoad(gameObject);
        }
    }
	public void ResetGame()
    {
		gameObject.SetActive(false);
		Destroy(gameObject);
    }
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
