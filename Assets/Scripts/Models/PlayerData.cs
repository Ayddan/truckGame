
using System;

[System.Serializable]
public class PlayerData
{
    public int score = 0;
    public float timerDuration;
    public float elapsedTime;

    public PlayerData(float timerDuration)
    {
        this.timerDuration = timerDuration;
    }
}
