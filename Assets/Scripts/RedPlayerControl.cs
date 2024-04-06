using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedPlayerControl : MonoBehaviour
{
    [SerializeField]
    float _jumpForce = 4.0f;
    [SerializeField]
    float _translationForce = 4.0f;
    Rigidbody _rigidBody;

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

    private void OnCollisionEnter(Collision other)
    {
        _jumpCount = 0;
    }
}
