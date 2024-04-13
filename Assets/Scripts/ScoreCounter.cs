using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreCounter : MonoBehaviour
{
    private int scoreRed = 0;
    private int scoreBlue = 0;
    
    public string sceneForRedPlayer = "SecondScene";
    public string sceneForBluePlayer = "FirstScene";
    public TextMeshProUGUI RedScore;
    public TextMeshProUGUI BlueScore;
    public TextMeshProUGUI winTextRed;
    public TextMeshProUGUI winTextBlue;

    // Start is called before the first frame update
    void Start()
    {
        scoreRed = PlayerPrefs.GetInt("ScoreRed", 0);
        scoreBlue = PlayerPrefs.GetInt("ScoreBlue", 0);
        UpdateScoreText();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Plane"))
        {
            if (collision.transform.position.x < transform.position.x)
            {
                IncreaseBlueScore();
                SaveScore();
                ReloadSceneForBlue();
            }
            else
            {

                IncreaseRedScore();
                SaveScore();
                ReloadSceneForRed();
            }
        }


        if (collision.gameObject.CompareTag("Ground"))
        {
            if (collision.transform.position.x < transform.position.x)
            {
                IncreaseRedScore();
                SaveScore();
                ReloadSceneForRed();
            }
            else
            {
                IncreaseBlueScore();
                SaveScore();
                ReloadSceneForBlue();


            }
        }
    }
    private void CheckWinCondition()
    {
        if (scoreRed >= 10)
        {
            winTextRed.text = "Jucătorul roșu a câștigat!";
            
        }
        else if (scoreBlue >= 10)
        {
            winTextBlue.text = "Jucătorul albastru a câștigat!";
        }
    }
    private void SaveScore()
    {
        PlayerPrefs.SetInt("ScoreRed", scoreRed);
        PlayerPrefs.SetInt("ScoreBlue", scoreBlue);
        PlayerPrefs.Save();
    }
    private void IncreaseRedScore()
    {
        scoreRed++;
        UpdateScoreText();
        CheckWinCondition();
    }
    private void IncreaseBlueScore() 
    {
        scoreBlue++;
        UpdateScoreText();
        CheckWinCondition();

    }

    private void UpdateScoreText()
    {
        RedScore.text = scoreRed.ToString();
        BlueScore.text = scoreBlue.ToString();
    }
    private void ReloadSceneForRed()
    {
        if (scoreRed<10)
        {
            SceneManager.LoadScene(sceneForRedPlayer);
        }
    }
    private void ReloadSceneForBlue()
    {
        if (scoreBlue < 10)
        {
            SceneManager.LoadScene(sceneForBluePlayer);
        }
    }

}
