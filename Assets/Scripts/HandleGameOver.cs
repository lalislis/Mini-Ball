using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HandleGameOver : MonoBehaviour
{
    private bool isGoal = false;
    [SerializeField] TMP_Text currentScoreText;
    [SerializeField] TMP_Text lastScoreText;
    [SerializeField] TMP_Text highScoreText;
    [SerializeField] GameObject gameOverUI;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Goal")
        {
            isGoal = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Destroy")
        {
            if (!isGoal)
            {
                gameOver();
            }

            Destroy(gameObject);
        }
    }

    void gameOver()
    {
        int lastScore = int.Parse(currentScoreText.text);
        lastScoreText.text = lastScore.ToString();
        setHighScore(lastScore);

        gameOverUI.SetActive(true);
    }

    void setHighScore(int score)
    {
        int highScore = PlayerPrefs.GetInt("highscore_basketball");
        if (highScore < score)
        {
            PlayerPrefs.SetInt("highscore_basketball", score);
            highScore = score;
        }

        highScoreText.text = highScore.ToString();
    }
}
