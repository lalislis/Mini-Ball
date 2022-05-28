using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Hitpoint : MonoBehaviour
{
    [SerializeField] TMP_Text scoreText;
    private int score = 0;

    AudioSource pointSound;

    void Start()
    {
        scoreText.text = score.ToString();
        pointSound = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ball")
        {
            updateScore();
        }
    }

    private void updateScore()
    {
        if (pointSound != null)
        {
            pointSound.Play();
        }

        score = score + 1;
        scoreText.text = score.ToString();
    }
}
