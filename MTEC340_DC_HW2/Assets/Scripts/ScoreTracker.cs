using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class ScoreTracker : MonoBehaviour
{
    [SerializeField] private int _score = 0; //backing variable
    [SerializeField] private TextMeshProUGUI _scoreTextUI;
    
    
    public int Score //getter and setter properties
    {
        get => _score;
        set => _score = value;
    }
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            _score++;
            //increase the value of the _score integer every time the object assigned to this script
            //collides with an object who carries the tag "Ball"
        }
    }

    void Update()
    {
        _scoreTextUI.SetText(_score.ToString()); 
        //this updates the TMP text to a string value, or in this case, our _score which is an integer
    }
    
}
