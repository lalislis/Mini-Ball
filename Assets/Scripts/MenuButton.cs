using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuButton : MonoBehaviour
{
    [SerializeField] GameObject pauseUI;

    public void pauseGame()
    {
        Time.timeScale = 0f;
        pauseUI.SetActive(true);
    }

    public void resumeGame()
    {
        Time.timeScale = 1f;
        pauseUI.SetActive(false);
    }
}
