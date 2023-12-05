using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {


	[SerializeField] Paddle paddle1;
    [SerializeField] float launchVectorX = 2f;
    [SerializeField] float launchVectorY = 15f;
    [SerializeField] AudioClip[] ballSounds;

	Vector2 paddleToBallVector;
    bool hasLaunched = false;


    AudioSource myAudioSource;
	// Use this for initialization
	void Start () 
	{
        hasLaunched = false;
        paddleToBallVector = transform.position - paddle1.transform.position;
        myAudioSource = GetComponent<AudioSource>();
	}

	// Update is called once per frame
	void Update()
    {
        if(!hasLaunched)
        {
            LockBallToPaddle();
		    LaunchOnMouseClick();
        }
           
    }

    private void LaunchOnMouseClick()
    {
        if(Input.GetMouseButtonDown(0))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(launchVectorX, launchVectorY);
            hasLaunched = true;
        }
    }

    private void LockBallToPaddle()
    {
        Vector2 paddlePos = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
        transform.position = paddlePos + paddleToBallVector;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(hasLaunched)
        {
            AudioClip clip = ballSounds[UnityEngine.Random.Range(0, ballSounds.Length)];

            myAudioSource.PlayOneShot(clip);

        }
    }
}
