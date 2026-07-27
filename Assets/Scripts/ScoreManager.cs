using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    int score = 0;

    public void AddScore(int amount)
    {
        score += amount;
        scoreText.text = "SCORE: " + score;
    }
}
