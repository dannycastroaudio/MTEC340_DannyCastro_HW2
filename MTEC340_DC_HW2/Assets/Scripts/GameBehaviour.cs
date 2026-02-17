using UnityEngine;
using System;

public class GameBehaviour : MonoBehaviour
{
    public static  GameBehaviour Instance;
    [SerializeField] private GameObject _ballPrefab;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        Serve();
    }

    private void Serve()
    {
        Instantiate(_ballPrefab, Vector3.zero, Quaternion.identity); // game object, location, and rotation
    }

    public void Score()
    {
        Invoke(nameof(Serve), 2.0f); // Invoke function 
    }
    
}
