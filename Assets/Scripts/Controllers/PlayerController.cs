using JetBrains.Annotations;
using UnityEditor;
using UnityEngine;

public class PlayerController
{
    private PlayerData playerData;
    private PlayerView playerView;

    public PlayerController(PlayerData data, PlayerView view)
    {
        playerData = data;
        playerView = view;
    }

    public void ChangePlayerScore(int scoreChange)
    {
        playerData.score += scoreChange;
        if (playerData.score < 0)
        {
            playerData.score = 0;
        }
    }

    public int GetScore()
    {
        return playerData.score;
    }

}