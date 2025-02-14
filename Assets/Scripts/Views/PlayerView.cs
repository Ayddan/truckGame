using System.Collections;
using TMPro;
using UnityEngine;

public class PlayerView : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    public void UpdateScore(int score) => scoreText.text = $"SCORE : {score}";
}
