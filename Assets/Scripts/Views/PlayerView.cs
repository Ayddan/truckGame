using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class PlayerView : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    private void Update()
    {
        scoreText.text = $"SCORE : {GameManager.Instance.playerController.GetScore()}";
    }
}
