using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Game_Manager : MonoBehaviour
{
    public static Game_Manager Instance;

    [Header("UI Referenzen")]
    public GameObject gameOverPanel;
    public TMP_Text scoreText;

    private bool isGameOver = false;

    void Awake()
    {
        // Singleton damit andere Scripts drauf zugreifen können
        Instance = this;
    }

    public void GameOver(int finalScore)
    {
        if (isGameOver) return;
        isGameOver = true;

        // Zeit anhalten
        Time.timeScale = 0f;

        // Game Over Panel anzeigen
        gameOverPanel.SetActive(true);
        scoreText.text = "Distanz: " + finalScore;
    }

    public void RestartGame()
    {
        // Zeit wieder starten
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}