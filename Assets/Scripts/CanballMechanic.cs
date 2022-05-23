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

    Vector3 piramidPos;
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

            if ((int) lockTimer <= timerSoundInSeconds && !isPlayingTimer)
            {
                isPlayingTimer = true;
                if (timerSound != null) timerSound.Play();
            }
        }
        else
        {
            gameOver();
        }
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
}
