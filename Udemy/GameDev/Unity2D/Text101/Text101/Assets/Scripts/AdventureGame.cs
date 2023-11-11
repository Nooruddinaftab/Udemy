using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class AdventureGame : MonoBehaviour {

	[SerializeField] Text storyTextComponent;
	[SerializeField] State startingState;

	State currentState;

	// Use this for initialization
	void Start () {
		currentState = startingState;
		storyTextComponent.text = currentState.GetStateStory();
	}
	
	// Update is called once per frame
	void Update () {
		ManageState();
	}

	private void ManageState()
	{
		var nextStates = currentState.GetNextStates();

		if (nextStates.Length >= 1 && Input.GetKeyDown(KeyCode.Alpha1))
		{
			currentState = nextStates[0];
		}
		else if (nextStates.Length >= 2 && (Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Q)))
        {
			currentState = nextStates[1];

		}
		else if (nextStates.Length >= 3 && Input.GetKeyDown(KeyCode.Alpha3))
		{
			currentState = nextStates[2];
		}

		storyTextComponent.text = currentState.GetStateStory();
	}
}
