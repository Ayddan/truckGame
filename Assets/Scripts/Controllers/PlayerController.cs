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

        // Set start value
        playerView.UpdateScore(playerData.score);
    }

    public void ChangePlayerScore(int scoreChange)
    {
        playerData.score += scoreChange;
        playerView.UpdateScore(playerData.score);
    }

}