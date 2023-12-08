﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //config params
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float padding;
    [SerializeField] GameObject laserPrefab;
    [SerializeField] float projectileSpeed = 10f;
    [SerializeField] float projectileFiringPeriod = 0.1f;


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
