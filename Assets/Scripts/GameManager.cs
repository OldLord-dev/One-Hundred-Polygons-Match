using System;
using TMPro;
using UnityEngine;

public enum GameState
{
    MainMenu,
    Game,
    Pause,
    LevelFinished
}
public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameState state;

    public static event Action<GameState> OnGameStateChanged;
    public int points = 0;

    [SerializeField] private GameObject gameGrid;
    [SerializeField] private GameObject spawner;
    [SerializeField] private TextMeshProUGUI pointsText;
    [SerializeField] private TextMeshProUGUI highScoreText;
    [SerializeField] private Timer timer;
    void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        UpdateGameState(GameState.MainMenu);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && state==GameState.Game)
        {
            UpdateGameState(GameState.Pause);
        }
    }
            public void UpdateGameState(GameState newState)
    {
        state = newState;

        switch (newState)
        {
            case GameState.MainMenu:
                HandleMainMenu();
                break;
            case GameState.Game:
                HandleGameState();
                break;
            case GameState.Pause:
                HandlePauseState();
                break;
            case GameState.LevelFinished:
                LevelFinishedState();
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(newState), newState, null);
        }
        OnGameStateChanged(newState);
    }

    public void AddPoint()
    {
        points++;
        pointsText.text = $"Score:\n {points}";
    }
    private void HandleMainMenu()
    {
        points = 0;
        timer.ResetTime();
        pointsText.text = $"Score:\n {points}";
    }

    private void LevelFinishedState()
    {
        gameGrid.SetActive(false);
        spawner.SetActive(false);
        if(PlayerPrefs.GetInt("HighScore") < points)
            PlayerPrefs.SetInt("HighScore",points);
        highScoreText.text = $"Best Score: {PlayerPrefs.GetInt("HighScore")}";
    }
    private void HandlePauseState()
    {
        Time.timeScale = 0;
    }
    private void HandleGameState()
    {
        Time.timeScale = 1;
        gameGrid.SetActive(state == GameState.Game);
        spawner.SetActive(state == GameState.Game); 

    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
