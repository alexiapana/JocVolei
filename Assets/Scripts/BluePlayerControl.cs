using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BluePlayerControl : MonoBehaviour
{
    [SerializeField]
    float _jumpForce = 3.0f;
    [SerializeField]
    float _translationForce = 1.0f;
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

    private void OnCollisionEnter(Collision other)
    {
        _jumpCount = 0;
    }
}
