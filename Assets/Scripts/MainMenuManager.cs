using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] private GameObject mainMenu;   
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
        mainMenu.SetActive(state == GameState.MainMenu);
    }
    
    public void OnStartButtonPressed()
    {
        GameManager.instance.UpdateGameState(GameState.Game);
    }

    public void OnExitButtonPressed()
    {
        GameManager.instance.ExitGame();
    }
}
