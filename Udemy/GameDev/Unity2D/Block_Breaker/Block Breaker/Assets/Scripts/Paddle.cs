using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {


	[SerializeField] float screenWidthInUnits = 16f;
	[SerializeField] float minPosOnScreenInUnits = 1f;
	[SerializeField] float maxPosOnScreenInUnits = 15f;

	Vector2 mousePos;
	float mousePosInUnits = 0f;


    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		mousePosInUnits = (Input.mousePosition.x / Screen.width) * screenWidthInUnits;
		//Debug.Log(mousePosInUnits);

		//mousePos = new Vector2((Input.mousePosition.x / Screen.width) * screenWidthInUnits, paddleTransform.position.y);
		mousePos.x = Mathf.Clamp(mousePosInUnits, minPosOnScreenInUnits, maxPosOnScreenInUnits);
		mousePos.y = transform.position.y;
		transform.position = mousePos;
	}
}
