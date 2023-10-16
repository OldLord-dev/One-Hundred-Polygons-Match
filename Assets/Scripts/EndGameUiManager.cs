using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EndGameUiManager : MonoBehaviour
{
    [SerializeField] private GameObject endGameUi;
    private void Awake()
    {
        GameManager.OnGameStateChanged += GameManagerOnGameStateChanged;
    }
    private void OnDestroy()
    {
        GameManager.OnGameStateChanged -= GameManagerOnGameStateChanged;
    }
    private void GameManagerOnGameStateChanged(GameState state)
    {
        endGameUi.SetActive(state == GameState.LevelFinished);
    }
    public void OnMainMenuButtonPressed()
    {
        GameManager.instance.UpdateGameState(GameState.MainMenu);
    }
}
