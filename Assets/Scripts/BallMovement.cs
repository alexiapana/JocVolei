using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public float moveSpeed = 7f;

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
    }
}
