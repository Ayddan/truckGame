using TMPro;
using UnityEngine;

public class GameOverView : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    void Update()
    {
        scoreText.text = $"You scored {GameManager.Instance.playerController.GetScore()}";
    }


}
