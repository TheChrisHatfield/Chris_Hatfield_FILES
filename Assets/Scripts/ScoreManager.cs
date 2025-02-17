using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public Text scoreText;
    private int score = 0;

    void Awake()
    {
        // Ensure only one instance of ScoreManager exists
        if (instance == null)
        {
            instance = this;
        }
    }

    public void AddScore(int points)
    {
        score += points;
        scoreText.text = "Score: " + score;
        Debug.Log("Current Score: " + score);
    }
}
