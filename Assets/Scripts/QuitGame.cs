using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitGame : MonoBehaviour
{
    private int scoreRed = 0;
    private int scoreBlue = 0;

    void Start()
    {
        // Inițializare scor la începutul aplicației
        ResetScore();
    }

    void ResetScore()
    {
        PlayerPrefs.DeleteKey("ScoreRed");
        PlayerPrefs.DeleteKey("ScoreBlue");
        scoreRed = 0;
        scoreBlue = 0;
    }

    void SaveScore()
    {
        PlayerPrefs.SetInt("ScoreRed", scoreRed);
        PlayerPrefs.SetInt("ScoreBlue", scoreBlue);
        PlayerPrefs.Save();
    }

    void Update()
    {
        // Verificăm dacă butonul Escape este apăsat
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // Salvăm scorul și închidem aplicația
            SaveScore();
            Application.Quit();
        }
    }
}
