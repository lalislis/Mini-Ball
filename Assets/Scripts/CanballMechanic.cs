using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CanballMechanic : MonoBehaviour
{
    [SerializeField] TMP_Text scoreText;
    [SerializeField] TMP_Text timerText;
    [SerializeField] GameObject cloneTarget;
    [SerializeField] Transform piramid;
    [SerializeField] int maxUnit = 10;
    [SerializeField] float timerInSeconds = 60f;
    [SerializeField] GameObject gameOverUI;
    [SerializeField] TMP_Text lastScoreText;
    [SerializeField] TMP_Text highScoreText;

    Vector3 piramidPos;
    private int score = 0;
    private float lockTimer;

    void Start()
    {
        scoreText.text = score.ToString();
        timerText.text = timerInSeconds.ToString();
        piramidPos = piramid.position;
        lockTimer = timerInSeconds + 1;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Kaleng")
        {
            updateScore();
            generateTarget();
        }

        Destroy(collision.gameObject);
    }

    void Update()
    {
        if ((int) lockTimer > 0)
        {
            lockTimer -= Time.deltaTime;
            timerText.text = ((int) lockTimer).ToString();
        } 
        else
        {
            gameOver();
        }
    }

    void updateScore()
    {
        score = score + 1;
        scoreText.text = score.ToString();
    }

    void generateTarget()
    {
        Debug.Log(score % maxUnit);
        if (score % maxUnit == 0)
        {
            destroyPiramid();
            Instantiate(cloneTarget, piramidPos, Quaternion.identity);
        }
    }

    void destroyPiramid()
    {
        GameObject piramid = GameObject.FindGameObjectWithTag("Piramid");
        Destroy(piramid);
    }

    void gameOver()
    {
        lastScoreText.text = score.ToString();
        setHighScore();

        gameOverUI.SetActive(true);
    }

    void setHighScore()
    {
        int highScore = PlayerPrefs.GetInt("highscore");
        if (highScore < score)
        {
            PlayerPrefs.SetInt("highscore", score);
            highScore = score;
        }

        highScoreText.text = highScore.ToString();
    }
}
