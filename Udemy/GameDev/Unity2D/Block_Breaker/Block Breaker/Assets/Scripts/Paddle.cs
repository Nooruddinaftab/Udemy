using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {


	[SerializeField] float screenWidthInUnits = 16f;
	[SerializeField] float minPosOnScreenInUnits = 1f;
	[SerializeField] float maxPosOnScreenInUnits = 15f;

	Vector2 mousePos;
	float mousePosInUnits = 0f;

	//cache references
	GameSession myGameSession;
	Ball myBall;

    // Use this for initialization
    void Start () {
		myGameSession = FindObjectOfType<GameSession>();
		myBall = FindObjectOfType<Ball>();
	}
	
	// Update is called once per frame
	void Update () {
		mousePos.x = Mathf.Clamp(GetXPos(), minPosOnScreenInUnits, maxPosOnScreenInUnits);
		mousePos.y = transform.position.y;
		transform.position = mousePos;
	}

	private float GetXPos()
    {
		if(myGameSession.IsAutoPlayEnabled())
        {
			return myBall.transform.position.x;
        }
        else
        {
			return (Input.mousePosition.x / Screen.width) * screenWidthInUnits; 
		}
    }
}
