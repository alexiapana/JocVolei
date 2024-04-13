using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGameButton : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("FirstScene");
    }

    public void ShowControls()
    {
        SceneManager.LoadScene("Controls");
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
