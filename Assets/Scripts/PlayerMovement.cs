using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody _rb;

    [SerializeField] private float _runSpeed = 500f; // скорость куба
    [SerializeField] private float _strafeSpeed = 500f; // движение направо или  налево
    [SerializeField] private float _jumpForce = 10f; // сила прыжка

    private bool _strafeLeft = false;
    private bool _strafeRight = false;
    private bool _doJump = false;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Obstacle"))
        {
            print("End");
        }
    }

    void Update()
    {

        _strafeLeft = Input.GetKey(KeyCode.A);
        
        _strafeRight = Input.GetKey(KeyCode.D);

        _doJump = Input.GetKeyDown(KeyCode.W);
    }

    private void FixedUpdate()
    {
        _rb.MovePosition(transform.position + Vector3.left * (_runSpeed * Time.deltaTime));

        if (_strafeLeft)
        {
            _rb.MovePosition(transform.position - Vector3.forward * (_strafeSpeed * Time.deltaTime));
        }
        
        if (_strafeRight)
        {
            _rb.MovePosition(transform.position + Vector3.forward * (_strafeSpeed * Time.deltaTime));
        }

        if (_doJump)
        {
            _rb.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
            transform.DORewind();
            transform.DOShakeScale(0.5f, 0.5f, 3, 30);
        }
    }
}
