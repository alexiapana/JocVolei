using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedPlayerControl : MonoBehaviour
{
    [SerializeField]
    float _jumpForce = 4.0f;
    [SerializeField]
    float _translationForce = 10.0f;
    Rigidbody _rigidBody;

    [SerializeField]
    private GameObject volleyball;

    [SerializeField]
    public float moveSpeed = 3f;

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
        if (Input.GetKeyDown(KeyCode.UpArrow) && _jumpCount < _maxJump)
        {
            _rigidBody.velocity = new Vector3(_rigidBody.velocity.x, 0f, _rigidBody.velocity.z);
            _rigidBody.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
            _jumpCount++;
        }
    }

    void MovePlayer()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
            transform.Translate(_translationForce * Time.deltaTime * Vector3.right);
        else if (Input.GetKey(KeyCode.RightArrow))
            transform.Translate(_translationForce * Time.deltaTime * -Vector3.right);
    }

    void HitBall()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && IsBallClose())
        {
            Rigidbody ballRb = volleyball.GetComponent<Rigidbody>();
            if (ballRb != null && !ballRb.isKinematic)
            {
                Vector3 direction;
                direction.x = -moveSpeed;
                direction.y = 5f;
                direction.z = 0;

                ballRb.AddForce(direction, ForceMode.Impulse);
            }
        }
    }

    bool IsBallClose()
    {
        float allowedDistance = 7f;
        return Vector3.Distance(transform.position, volleyball.transform.position) <= allowedDistance;
    }


    private void OnCollisionEnter(Collision other)
    {
        _jumpCount = 0;
    }
}
