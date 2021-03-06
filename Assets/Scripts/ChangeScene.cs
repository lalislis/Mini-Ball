using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public void LoadScene(string sceneName){
        Time.timeScale = 1f;
        SceneManager.LoadScene(sceneName);
        Debug.Log("Scene changed to " + sceneName + "!");
    }

    public void QuitGame(){
        Application.Quit();
        Debug.Log("Game Closed");
    }
}
