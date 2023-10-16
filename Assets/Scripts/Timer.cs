using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class Timer : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI timeText;
    [SerializeField]
    private float testTime;
    private float timeRemaining;
    private bool timerIsRunning = false;
    void Start()
    {
        timerIsRunning = true;
    }

    public void ResetTime()
    {
        timerIsRunning = true;
        timeRemaining = testTime;
    }
    private void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
            }
            else
            {
                timeText.text = string.Format("Time:\n{0:00}:{1:00}", 0, 0, 0);
                timeRemaining = 0;
                timerIsRunning = false;
                GameManager.instance.UpdateGameState(GameState.LevelFinished);
            }
        }
    }
    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        float milliseconds = Mathf.FloorToInt(timeToDisplay * 1000f);
        milliseconds = milliseconds % 1000;
        timeText.text = string.Format("Time:\n{0:00}:{1:00}", minutes, seconds, milliseconds);
    }
}
