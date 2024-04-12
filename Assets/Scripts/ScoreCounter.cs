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
                SceneManager.LoadScene(sceneForBluePlayer);
            }
            else
            {

                IncreaseRedScore();
                SaveScore();
                SceneManager.LoadScene(sceneForRedPlayer);
            }
        }


        if (collision.gameObject.CompareTag("Ground"))
        {
            if (collision.transform.position.x < transform.position.x)
            {
                IncreaseRedScore();
                SaveScore();
                SceneManager.LoadScene(sceneForRedPlayer);
            }
            else
            {
                IncreaseBlueScore();
                SaveScore();
                SceneManager.LoadScene(sceneForBluePlayer);


            }
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
    }
    private void IncreaseBlueScore() 
    {
        scoreBlue++;
        UpdateScoreText();
    }

    void UpdateScoreText()
    {
        RedScore.text = scoreRed.ToString();
        BlueScore.text = scoreBlue.ToString()+ " - ";
    }
}
