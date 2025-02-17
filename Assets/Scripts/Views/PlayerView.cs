using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class PlayerView : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI timerText;

    private void Update()
    {
        scoreText.text = $"SCORE : {GameManager.Instance.playerController.GetScore()}";
        GameManager.Instance.playerController.UpdateTimer(Time.deltaTime);
        timerText.text = $"TIMER : {GameManager.Instance.playerController.GetFormattedTime()}";
    }
}
