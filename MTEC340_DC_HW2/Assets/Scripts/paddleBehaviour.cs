using System;
using UnityEngine;

public class PaddleBehaviour : MonoBehaviour
{
    [SerializeField] private float _speed = 3.0f;
    [SerializeField] private KeyCode _leftDirection = KeyCode.A;
    [SerializeField] private KeyCode _rightDirection = KeyCode.D;
    private Rigidbody2D _rb;
    private float _direction;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        _rb.linearVelocityX = _direction * _speed;
    }

    void Update()
    {
        _direction = 0.0f;
        if (Input.GetKey(_leftDirection))
        {
            _direction -= 1;
        }

        if (Input.GetKey(_rightDirection))
        {
            _direction += 1;
        }
    }
}
