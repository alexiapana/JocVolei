using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallMovement : MonoBehaviour
{
    public float moveSpeed = 7f;

    private Rigidbody rb;
    private int scoreRed = 0;
    private int scoreBlue = 0;

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
        if(collision.gameObject.CompareTag("Player"))
        {
            rb.isKinematic = false;
            Vector3 direction = (transform.position - collision.transform.position).normalized;
            direction.z = 0; // Asigură-te că nu modifici axa Z
            direction.y = 0; 

            Vector3 verticalLift = Vector3.up * 2f;

            Vector3 horizontalForce = direction * moveSpeed;

            rb.AddForce(horizontalForce + verticalLift, ForceMode.Impulse);

        }
        if (collision.gameObject.CompareTag("Plane"))
        {
            if (collision.transform.position.x < transform.position.x) 
            {
                scoreBlue++;
                SaveScore(); // Salvarea scorului
                SceneManager.LoadScene(sceneForBluePlayer);
            }
            else 
            { 

                scoreRed++;
                SaveScore(); // Salvarea scorului
                SceneManager.LoadScene(sceneForRedPlayer);
            }
        }

        // Actualizează scorul afișat în interfața grafică
        //scoreTextRed.text = "Scor Rosu: " + scoreRed.ToString();
        //scoreTextBlue.text = "Scor Albastru: " + scoreBlue.ToString();

        if (collision.gameObject.CompareTag("Ground"))
        {
            if (collision.transform.position.x < transform.position.x) // Partea jucătorului roșu
            {
                scoreRed++;
                SaveScore();
                SceneManager.LoadScene(sceneForRedPlayer);
            }
            else // Partea jucătorului albastru
            {
                scoreBlue++;
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
    private void OnDestroy()
    {
        SaveScore();
    }
}
