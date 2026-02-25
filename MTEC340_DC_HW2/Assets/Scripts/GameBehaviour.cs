using UnityEngine;
using System;
using TMPro;

public class GameBehaviour : MonoBehaviour
{
    public static  GameBehaviour Instance;
    [SerializeField] private GameObject _ballPrefab;
    private Utilities.GameState _gameMode;

    public Utilities.GameState GameMode
    {
        get => _gameMode;
        set
        {
            _gameMode = value;
            _pauseUI.enabled = GameMode != Utilities.GameState.Play;
        }
    }

    [SerializeField] private TMP_Text _pauseUI;

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
        GameMode = Utilities.GameState.Play;
        
        Serve();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            GameMode = GameMode == Utilities.GameState.Play ? Utilities.GameState.Pause : Utilities. GameState.Play;
        }
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
