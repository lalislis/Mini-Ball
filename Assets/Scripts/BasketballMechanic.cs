using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BasketballMechanic : MonoBehaviour
{
    [SerializeField] TMP_Text currentScoreText;
    [SerializeField] TMP_Text lastScoreText;
    [SerializeField] TMP_Text highScoreText;
    [SerializeField] GameObject gameOverUI;
    [SerializeField] Transform ball;
    [SerializeField] GameObject cloneBall;

    Vector3 ballPos;

    void Start()
    {
        ballPos = ball.position;
    }

    void FixedUpdate()
    {
        generateBall();
    }

    public void CollisionDetected(Collision collision)
    {
        GameObject collisionObject = collision.gameObject;
        if (collisionObject.tag == "Ball")
        {
            bool isGoal = collisionObject.GetComponent<CheckGoal>().getGoal();
            if (!isGoal)
            {
                gameOver();
            }

            Destroy(collisionObject);
        }
    }

    void gameOver()
    {
        int lastScore = int.Parse(currentScoreText.text);
        lastScoreText.text = lastScore.ToString();
        setHighScore(lastScore);

        Time.timeScale = 0f;
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

    void generateBall()
    {
        int countBall = GameObject.FindGameObjectsWithTag("Ball").Length;
        if (countBall <= 0)
        {
            SpawnBall();
        }
    }

    void SpawnBall()
    {
        GameObject newBall = Instantiate(cloneBall, ballPos, Quaternion.identity);

        //newBall.SetActive(true);
        //newBall.GetComponent<Throwball>().enabled = true;
        //newBall.GetComponent<AudioSource>().enabled = true;
    }
}
