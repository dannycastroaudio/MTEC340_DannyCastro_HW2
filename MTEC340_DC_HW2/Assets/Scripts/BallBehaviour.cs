using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class BallBehaviour : MonoBehaviour
{
    [SerializeField] private float _launchForce = 5.0f; //how fast I want my ball to launch
    [SerializeField] private float _paddleInfluence = 0.3f;
    [SerializeField] private float _speedMultiplier = 1.1f;
    private Rigidbody2D _rb;
    
    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        Vector2 direction = Random.insideUnitCircle;
        
        if (Mathf.Abs(direction.y) < 0.25f) 
            direction.y += 0.5f * Mathf.Sign (direction.y);
        _rb.AddForce(direction * _launchForce, ForceMode2D.Impulse);

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Paddle"))
        {
            if (Mathf.Approximately(other.rigidbody.linearVelocity.x, 0.0f))
            {
                Vector2 direction = _rb.linearVelocity * (1.0f - _paddleInfluence) + other.rigidbody.linearVelocity * _paddleInfluence;
                _rb.linearVelocity = _rb.linearVelocity.magnitude * direction.normalized;
            }

            _rb.linearVelocity *= _speedMultiplier;
            
        }
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        GameBehaviour.Instance.Score();
        Destroy(gameObject);
    }
    
}
