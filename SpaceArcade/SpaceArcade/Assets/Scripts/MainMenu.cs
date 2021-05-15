using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartSinglePlayer()
    {
        ScoreScript.score = 0;
        SceneManager.LoadScene("SceneSingleplayer");
    }

    public void StartMultiplayer()
    {
        SceneManager.LoadScene("Game");
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
