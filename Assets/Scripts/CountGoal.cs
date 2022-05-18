﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CountGoal : MonoBehaviour
{
    [SerializeField] TMP_Text scoreText;
    private int score = 0;

    void Start()
    {
        scoreText.text = score.ToString();
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
        score = score + 1;
        scoreText.text = score.ToString();
    }
}
