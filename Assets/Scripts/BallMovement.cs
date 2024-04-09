using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallMovement : MonoBehaviour
{
    public float moveSpeed = 0.3f;

    private Rigidbody rb;
    private int scoreRed = 0;
    private int scoreBlue = 0;
    //PlayerPrefs.DeleteKey("ScoreRed");
    //PlayerPrefs.DeleteKey("ScoreBlue");
    public string sceneForRedPlayer = "SecondScene";
    public string sceneForBluePlayer = "FirstScene";


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;

        scoreRed = PlayerPrefs.GetInt("ScoreRed", 0);
        scoreBlue = PlayerPrefs.GetInt("ScoreBlue", 0);

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            rb.isKinematic = false;

            Vector3 direction = (transform.position - collision.transform.position).normalized;
            if (direction.x < 0)
                direction.x = -moveSpeed;
            else
                direction.x = moveSpeed;

            direction.y = 1f;
            direction.z = 0;

            rb.AddForce(direction, ForceMode.Impulse);

        }
        if (collision.gameObject.CompareTag("Plane"))
        {
            if (collision.transform.position.x < transform.position.x)
            {
                scoreBlue++;
                Debug.Log("Scor Albastru: " + scoreBlue);
                SaveScore();
                SceneManager.LoadScene(sceneForBluePlayer);
            }
            else
            {

                scoreRed++;
                Debug.Log("Scor Rosu: " + scoreRed);
                SaveScore();
                SceneManager.LoadScene(sceneForRedPlayer);
            }
        }

        // Actualizează scorul afișat în interfața grafică
        //scoreTextRed.text = "Scor Rosu: " + scoreRed.ToString();
        //scoreTextBlue.text = "Scor Albastru: " + scoreBlue.ToString();

        if (collision.gameObject.CompareTag("Ground"))
        {
            if (collision.transform.position.x < transform.position.x)
            {
                scoreRed++;
                Debug.Log("Scor Rosu: " + scoreRed);
                SaveScore();
                SceneManager.LoadScene(sceneForRedPlayer);
            }
            else
            {
                scoreBlue++;
                Debug.Log("Scor Albastru: " + scoreBlue);
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

    //private void OnApplicationQuit()
    //{
    //    PlayerPrefs.DeleteKey("ScoreRed");
    //    PlayerPrefs.DeleteKey("ScoreBlue");
    //}
}
