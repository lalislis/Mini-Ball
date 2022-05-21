﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throwball : MonoBehaviour
{
    Vector2 mousePos, direction;
    Vector3 ballPos;
    float timeStart, intervalTime;
    bool isThrowed = false;

    [SerializeField] GameObject ball;
    [SerializeField] float addForceXY = 5f;
    [SerializeField] float addForceZ = 250f;

    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;
        ballPos = gameObject.transform.position;
    }

    void Update()
    {
        if (isThrowed) return;

        if (Input.GetMouseButtonDown(0))
        {
            timeStart = Time.time;
            mousePos = Input.mousePosition;
        }

        if (Input.GetMouseButtonUp(0))
        {
            isThrowed = true;
            intervalTime = (Time.time) - timeStart;
            direction = (Vector2) Input.mousePosition - mousePos;

            rb.isKinematic = false;
            Debug.Log(-direction.x + " " + -direction.y + " " + intervalTime);
            rb.AddForce(-direction.x * addForceXY, -direction.y * addForceXY, addForceZ / intervalTime);

            StartCoroutine(SpawnBall());
            Destroy(gameObject, 5f);
        }
    }

    public IEnumerator SpawnBall()
    {
        yield return new WaitForSeconds(3);
        Instantiate(ball, ballPos, Quaternion.identity);
    }
}
