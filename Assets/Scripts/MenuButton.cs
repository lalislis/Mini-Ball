using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuButton : MonoBehaviour
{
    [SerializeField] GameObject pauseUI;
    [SerializeField] GameObject gameOverUI;
    [SerializeField] ChangeScene changeScene;

    public void pauseGame()
    {
        if (isGameOver())
        {
            changeScene.LoadScene("Main Menu");
        }
        else
        {
            Time.timeScale = 0f;
            pauseUI.SetActive(true);
        }
    }

    public void resumeGame()
    {
        Time.timeScale = 1f;
        pauseUI.SetActive(false);
    }

    private bool isGameOver()
    {
        return gameOverUI.activeSelf;
    }
}
