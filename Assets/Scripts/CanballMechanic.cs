using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CanballMechanic : MonoBehaviour
{
    [SerializeField] TMP_Text scoreText;
    [SerializeField] GameObject cloneTarget;
    [SerializeField] Transform piramid;
    [SerializeField] int maxUnit = 10;

    Vector3 piramidPos;
    private int score = 0;

    void Start()
    {
        scoreText.text = score.ToString();
        piramidPos = piramid.position;
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

    void updateScore()
    {
        score = score + 1;
        scoreText.text = score.ToString();
    }

    void generateTarget()
    {
        if (score % maxUnit == 0)
        {
            Instantiate(cloneTarget, piramidPos, Quaternion.identity);
        }
    }
}
