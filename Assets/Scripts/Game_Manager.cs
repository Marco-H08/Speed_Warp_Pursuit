using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("UI Referenzen")]
    public GameObject gameOverPanel;
    public TMP_Text scoreText;
    public TMP_Text highscoreText; // Neu

    private bool isGameOver = false;

    void Awake()
    {
        Instance = this;
    }

    public void GameOver(int finalScore)
    {
        if (isGameOver) return;
        isGameOver = true;

        // Highscore prüfen und speichern
        int highscore = PlayerPrefs.GetInt("Highscore", 0);
        if (finalScore > highscore)
        {
            highscore = finalScore;
            PlayerPrefs.SetInt("Highscore", highscore);
            PlayerPrefs.Save();
        }

        Time.timeScale = 0f;
        gameOverPanel.SetActive(true);
        scoreText.text = "Distance: " + finalScore;
        highscoreText.text = "Highscore: " + highscore; // Neu

        // Counter ausblenden
        GameObject ball = GameObject.Find("Ball");
        if (ball != null)
        {
            DistanceCounter dc = ball.GetComponent<DistanceCounter>();
            if (dc != null && dc.counterText != null)
                dc.counterText.gameObject.SetActive(false);
        }
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}