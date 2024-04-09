using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BluePlayerControl : MonoBehaviour
{
    [SerializeField]
    float _jumpForce = 3.0f;
    [SerializeField]
    float _translationForce = 3.0f;
    Rigidbody _rigidBody;

    [SerializeField]
    private GameObject volleyball;

    [SerializeField]
    private float hitForce = 15f;

    private int _jumpCount = 0;
    private int _maxJump = 2;

    void Start()
    {
        _rigidBody = GetComponent<Rigidbody>();
        _rigidBody.freezeRotation = true;
    }

    void Update()
    {
        MovePlayer();
        Jump();
        HitBall();
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.W) && _jumpCount < _maxJump)
        {
            _rigidBody.velocity = new Vector3(_rigidBody.velocity.x, 0f, _rigidBody.velocity.z);
            _rigidBody.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
            _jumpCount++;
        }
    }

    void MovePlayer()
    {
        if (Input.GetKey(KeyCode.A))
            transform.Translate(_translationForce * Time.deltaTime * -Vector3.right);
        else if (Input.GetKey(KeyCode.D))
            transform.Translate(_translationForce * Time.deltaTime * Vector3.right);
    }

    void HitBall()
    {
        if (Input.GetKeyDown(KeyCode.Space) && IsBallClose())
        {
            Rigidbody ballRb = volleyball.GetComponent<Rigidbody>();
            if (ballRb != null && !ballRb.isKinematic)
            {
                Vector3 direction = new Vector3(transform.forward.x, 1, 0).normalized;
                ballRb.AddForce(direction * hitForce, ForceMode.Impulse);
            }
        }
    }

    bool IsBallClose()
    {
        float allowedDistance = 2f; 
        return Vector3.Distance(transform.position, volleyball.transform.position) <= allowedDistance;
    }

    private void OnCollisionEnter(Collision other)
    {
        _jumpCount = 0;
    }
}
