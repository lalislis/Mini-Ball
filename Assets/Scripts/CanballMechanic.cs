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
    [SerializeField] AudioSource timerSound;
    [SerializeField] int timerSoundInSeconds = 5;
    [SerializeField] Transform ball;
    [SerializeField] GameObject cloneBall;


    Vector3 piramidPos;
    Vector3 ballPos;
    AudioSource pointSound;
    private int score = 0;
    private float lockTimer;
    private bool isPlayingTimer = false;

    void Start()
    {
        pointSound = GetComponent<AudioSource>();

        scoreText.text = score.ToString();
        timerText.text = timerInSeconds.ToString();

        piramidPos = piramid.position;
        ballPos = ball.position;

        lockTimer = timerInSeconds + 1;
    }

    void FixedUpdate()
    {
        if ((int)lockTimer > 0)
        {
            lockTimer -= Time.deltaTime;
            timerText.text = ((int)lockTimer).ToString();

            if ((int)lockTimer <= timerSoundInSeconds && !isPlayingTimer)
            {
                isPlayingTimer = true;
                if (timerSound != null) timerSound.Play();
            }
        }
        else
        {
            gameOver();
        }

        generateBall();
    }

    public void CollisonDetected(Collision collision)
    {
        if (collision.gameObject.tag == "Kaleng")
        {
            updateScore();
            generateTarget();
        }

        Destroy(collision.gameObject);
    }

    void updateScore()
    {
        if (pointSound != null) pointSound.Play();
        score = score + 1;
        scoreText.text = score.ToString();
    }

    void generateTarget()
    {
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

        Time.timeScale = 0f;
        gameOverUI.SetActive(true);
        if (timerSound != null) timerSound.Stop();
    }

    void setHighScore()
    {
        int highScore = PlayerPrefs.GetInt("highscore_canball");
        if (highScore < score)
        {
            PlayerPrefs.SetInt("highscore_canball", score);
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
