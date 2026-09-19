// Author: Curtis Been
// Date: 2025-05-18
// Controls game state, scoring, and restart logic

using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public TextMeshProUGUI scoreText;
    public GameObject gameOverPanel;
    public AudioClip appleClip;
    public AudioClip zapClip;
    private AudioSource audioSource;

    public int score = 0;
    private bool isGameOver = false;

    private void Awake()
    {
        Instance = this;
        audioSource = GetComponent<AudioSource>();
        gameOverPanel.SetActive(false);

    }

    public void AddScore()
    {
        score++;
        scoreText.text = "Score: " + score;
        audioSource.PlayOneShot(appleClip);
    }

    public void GameOver()
    {
        if (isGameOver) return;
        isGameOver = true;
        gameOverPanel.SetActive(true);
        audioSource.PlayOneShot(zapClip);
        Time.timeScale = 0;
    }

    public void RestartGame()
    {
        Time.timeScale = 1;
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
}
