using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throwball : MonoBehaviour
{
    Vector2 mousePos, direction;
    float timeStart, intervalTime;
    bool isThrowed = false;

    [SerializeField] float addForceXY = 5f;
    [SerializeField] float addForceZ = 250f;
    [SerializeField] AudioSource tinSound;

    Rigidbody rb;
    AudioSource swipeSound;

    void Start()
    {
        swipeSound = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Kaleng")
        {
            if (tinSound != null) tinSound.Play();
        }
    }

   private void OnMouseDown()
   {
        timeStart = Time.time;
        mousePos = Input.mousePosition;
   }

    private void OnMouseUp()
    {
        if (isThrowed) return;

        intervalTime = (Time.time) - timeStart;
        direction = (Vector2)Input.mousePosition - mousePos;

        if (!isThrowable(direction.x, direction.y, intervalTime)) return;
        if (swipeSound != null) swipeSound.Play();

        isThrowed = true;
        rb.isKinematic = false;
        rb.AddForce(direction.x * addForceXY, direction.y * addForceXY, addForceZ / intervalTime);

        Destroy(gameObject, 4f);
    }

    private bool isThrowable(float x , float y, float time)
    {
        return ((time != Mathf.Infinity && time != 0) && (x != 0 || x != 0));
    }
}
