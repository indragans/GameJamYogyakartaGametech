using UnityEngine;
using TMPro;   // Kalau pakai TextMeshPro, kalau masih pakai UI Text ganti ke UnityEngine.UI

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;   // Singleton biar gampang dipanggil dari script lain

    public int currentScore = 0;
    public TextMeshProUGUI scoreText;      // Drag text UI ke sini lewat Inspector

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    void Start()
    {
        UpdateScoreUI();
    }

    public void AddScore(int amount)
    {
        currentScore += amount;
        UpdateScoreUI();
    }

    void UpdateScoreUI()
    {
        if (scoreText != null)
            scoreText.text = "Score: " + currentScore.ToString();
    }
}
