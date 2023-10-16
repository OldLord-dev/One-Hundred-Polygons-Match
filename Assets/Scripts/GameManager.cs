using System;
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

    [SerializeField] private GameObject gameGrid;
    void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        UpdateGameState(GameState.MainMenu);
    }

    public void UpdateGameState(GameState newState)
    {
        state = newState;

        switch (newState)
        {
            case GameState.MainMenu:
                break;
            case GameState.Game:
                HandleGameState();
                break;
            case GameState.Pause:
                break;
            case GameState.LevelFinished:
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(newState), newState, null);
        }
        OnGameStateChanged(newState);
    }
    // Update is called once per frame
    private void HandleGameState()
    {
        gameGrid.SetActive(state == GameState.Game);
    }
}
