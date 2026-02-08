using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class BallBehaviour : MonoBehaviour
{
    [SerializeField] private float _launchForce = 5.0f; //how fast I want my ball to launch
    private Rigidbody2D _rb;
    
    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        ResetBall(); //on start, reset ball

    }

    float GetNonZeroRandomFloat(float min = -1.0f, float max = 1.0f)
    {
        float num;
        do
        {
            num = Random.Range(min, max);
        } while (Mathf.Approximately(num, 0.0f));
        return num;
    }

    void ResetBall()
    {
        _rb.linearVelocity = Vector2.zero;
        transform.position = new Vector3 (0, -2, 0f); //I don't want it to start at 0, 0 ,0 coordinates, so I changed this.
        _rb = GetComponent<Rigidbody2D>();
        Vector2 direction = new Vector2(GetNonZeroRandomFloat(), GetNonZeroRandomFloat()).normalized;
        _rb.AddForce(direction * _launchForce, ForceMode2D.Impulse); //basically triggers ball movement
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        ResetBall(); 
    }
    
}
