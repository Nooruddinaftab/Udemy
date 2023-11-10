using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class AdventureGame : MonoBehaviour {

	[SerializeField] Text storyTextComponent;
	[SerializeField] Text titleTextComponent;

	// Use this for initialization
	void Start () {
		titleTextComponent.text = "phunk funk Game";
		//titleTextComponent.fontSize = 21;
		storyTextComponent.text = "set in program";
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
