using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throwball : MonoBehaviour
{
    Vector2 mousePos, direction;
    float timeStart, timeFinish, intervalTime;

    [SerializeField] GameObject basketball;
    Vector3 ballPos;

    [SerializeField] float addForceXY = 1f;
    [SerializeField] float addForceZ = 50f;

    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;

        gameObject.name = "Basketball";
        ballPos = gameObject.transform.position;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            timeStart = Time.time;
            mousePos = Input.mousePosition;
        }

        if (Input.GetMouseButtonUp(0))
        {
            intervalTime = (Time.time) - timeStart;
            direction = (Vector2) Input.mousePosition - mousePos;

            rb.isKinematic = false;
            rb.AddForce(-direction.x * addForceXY, -direction.y * addForceXY, addForceZ / intervalTime);

            Destroy(gameObject, 5f);

            StartCoroutine(SpawnBall());
        }
    }

    IEnumerator SpawnBall()
    {
        yield return new WaitForSeconds(3);
        Instantiate(basketball, ballPos, Quaternion.identity);
    }
}
