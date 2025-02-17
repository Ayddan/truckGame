using System;
using JetBrains.Annotations;
using UnityEditor;
using UnityEngine;

public class PlayerController
{
    private PlayerData playerData;
    private PlayerView playerView;

    private Action onTimerComplete;

    public PlayerController(PlayerData data, PlayerView view, Action onTimerComplete)
    {
        playerData = data;
        playerView = view;
        this.onTimerComplete = onTimerComplete;
    }

    public void ChangePlayerScore(int scoreChange)
    {
        playerData.score += scoreChange;
        if (playerData.score < 0)
        {
            playerData.score = 0;
        }
    }

    public void ResetPlayerScore()
    {
        playerData.score = 0;
    }

    public int GetScore()
    {
        return playerData.score;
    }

    public void AddTime(float time)
    {
        playerData.timerDuration += time;
    }

    public void UpdateTimer(float deltaTime)
    {
        playerData.elapsedTime += deltaTime;

        if (playerData.elapsedTime >= playerData.timerDuration)
        {
            onTimerComplete?.Invoke();
        }
    }

    // Get formatted time as MM:SS
    public string GetFormattedTime()
    {
        float remainingTime = Mathf.Max(playerData.timerDuration - playerData.elapsedTime, 0);
        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);
        return $"{minutes:D2}:{seconds:D2}";
    }

}