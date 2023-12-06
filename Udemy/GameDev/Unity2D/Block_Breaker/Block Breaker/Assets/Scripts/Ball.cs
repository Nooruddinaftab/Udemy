using UnityEngine;

public class Ball : MonoBehaviour {


	[SerializeField] Paddle paddle1;
    [SerializeField] float launchVectorX = 2f;
    [SerializeField] float launchVectorY = 15f;
    [SerializeField] AudioClip[] ballSounds;
    [SerializeField] float randomFactor = 0.2f;

	Vector2 paddleToBallVector;
    bool hasLaunched = false;

    //cache ref
    AudioSource myAudioSource;
    Rigidbody2D myRigidBody2d;

	// Use this for initialization
	void Start () 
	{
        hasLaunched = false;
        paddleToBallVector = transform.position - paddle1.transform.position;
        myAudioSource = GetComponent<AudioSource>();
        myRigidBody2d = GetComponent<Rigidbody2D>();
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
            myRigidBody2d.velocity = new Vector2(launchVectorX, launchVectorY);
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
        Vector2 velocityTweek = new Vector2(Random.Range(0f, randomFactor), Random.Range(0f, randomFactor));

        if(hasLaunched)
        {
            AudioClip clip = ballSounds[UnityEngine.Random.Range(0, ballSounds.Length)];

            myAudioSource.PlayOneShot(clip);
            myRigidBody2d.velocity += velocityTweek;
        }
    }
}
