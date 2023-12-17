using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //config params
    [Header("Player Movement")]
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float padding;

    [Header("Projectile")]
    [SerializeField] GameObject laserPrefab;
    [SerializeField] float projectileSpeed = 10f;
    [SerializeField] float projectileFiringPeriod = 0.1f;
    [SerializeField] float health = 1000;

    [Header("Player Sounds")]
    [SerializeField] AudioClip deathSFX;
    [SerializeField] [Range(0, 1)] float deathSoundVolume = 0.7f;
    [SerializeField] AudioClip shootSFX;
    [SerializeField] [Range(0, 1)] float shootSoundVolume = 0.2f;


    Coroutine firingCoroutine;
    bool coroutineStarted = false;

    private float xMin;
    private float xMax;
    private float yMin;
    private float yMax;
   
    // Start is called before the first frame update
    void Start()
    {
        SetupMoveBoundaries();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Fire();
        DestroyPlayer();
    }
    public void DestroyPlayer()
    {
        if (health <= 0)
            Die();
    }
    public float GetHealth()
    {
        return health;
    }
    private void Die()
    {
        FindObjectOfType<Level>().LoadGameOverScene();
        Destroy(gameObject);
        AudioSource.PlayClipAtPoint(deathSFX, Camera.main.transform.position, deathSoundVolume);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<DamageDealer>())
        {
            DamageDealer damageDealer = other.GetComponent<DamageDealer>();
            health -= damageDealer.GetDamage();
            damageDealer.Hit(this);
        }
    }
    private void Fire()
    {
        if (Input.GetButtonDown("Fire1") && !coroutineStarted)
        {
            firingCoroutine = StartCoroutine(FireContinuosly());
            coroutineStarted = true;
        }
        if (Input.GetButtonUp("Fire1"))
        {
            StopCoroutine(firingCoroutine);
            coroutineStarted = false;
        }
    }
    IEnumerator FireContinuosly()
    {
        while (true)
        {
            GameObject laser = Instantiate(laserPrefab, transform.position, Quaternion.identity) as GameObject;
            laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, projectileSpeed);
            AudioSource.PlayClipAtPoint(shootSFX, Camera.main.transform.position, shootSoundVolume);
            yield return new WaitForSeconds(projectileFiringPeriod);
        }

    }
    private void Move()
    {
        var deltaX = Input.GetAxis("Horizontal");
        var deltaY = Input.GetAxis("Vertical");
        var newXPos = Mathf.Clamp(transform.position.x + (deltaX * Time.deltaTime * moveSpeed), xMin, xMax);
        var newYPos = Mathf.Clamp(transform.position.y + (deltaY * Time.deltaTime * moveSpeed), yMin, yMax);
        transform.position = new Vector2(newXPos, newYPos);

        // for tilt
        deltaX = Input.acceleration.x;
        deltaY = Input.acceleration.y;
        newXPos = Mathf.Clamp(transform.position.x + (deltaX * Time.deltaTime * moveSpeed), xMin, xMax);
        newYPos = Mathf.Clamp(transform.position.y + (deltaY * Time.deltaTime * moveSpeed), yMin, yMax);
        transform.position = new Vector2(newXPos, newYPos);
    }
    private void SetupMoveBoundaries()
    {
        Camera gameCamera = Camera.main;
        xMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + padding;
        xMax = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - padding;
        yMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + padding;
        yMax = gameCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - padding;
    }
}
