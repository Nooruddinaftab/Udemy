using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberWizard : MonoBehaviour {

	int max_n = 1000;
	int min_n = 1;
	int guess_m = 500;
	// Use this for initialization
	void Start () {
		StartGame();
	}
	
	void StartGame()
    {
		Initialize();
		Debug.Log("welcome to number wizard");
		Debug.Log("Pick a number, do not tell me ");
		Debug.Log("Highest number is " + max_n);
		Debug.Log("Lowest number is " + min_n);

		Debug.Log("press following keys if your picked number is higher than " + guess_m + " press UP, other wise press Down arrow ");
		Debug.Log("Press Enter if " + guess_m + " is your picked number ");
		max_n = max_n + 1;
	}
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.UpArrow))
        {
			//Debug.Log("up arrow pressed");
			min_n = guess_m;

			NextGuess();
			
			//Debug.Log(guess_m);
			DisplayMessage();
		}
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
			//Debug.Log("down arrow pressed");
			max_n = guess_m;

			NextGuess();

			//Debug.Log(guess_m);
			DisplayMessage();
		}
		else if (Input.GetKeyDown(KeyCode.Return))
		{
			Debug.Log("Great !number is");
			Debug.Log(guess_m);

			StartGame();
		}
	}

	void Initialize()
    {
		max_n = 1000;
		min_n = 1;
		guess_m = 500;
	}
	void DisplayMessage()
    {
		Debug.Log("press following keys if your picked number is higher than " + guess_m + " press UP, other wise press Down arrow ");
		Debug.Log("Press Enter if " + guess_m + " is your picked number ");
	}

	void NextGuess()
    {
		guess_m = (min_n + max_n) / 2;
	}
}
