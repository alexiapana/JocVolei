using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallMovement : MonoBehaviour
{
    public float moveSpeed = 0.3f;

    private Rigidbody rb;
    


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;

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
        
    }
    
}
