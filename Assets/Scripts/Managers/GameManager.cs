using System;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] PlayerController playerController;
    [SerializeField] TMP_Text timeText;
    [SerializeField] GameObject gameOverText;
    [SerializeField] float startTime = 5f;

    bool gameOver = false;
    float timeLeft;

    public bool GameOver => gameOver;

    void Start()
    {
        timeLeft = startTime;
    }

    void Update()
    {
        bool flowControl = DecreaseTime();
        if (!flowControl)
        {
            return;
        }
    }

    bool DecreaseTime()
    {
        if (gameOver) return false;

        timeLeft -= Time.deltaTime;
        timeText.text = timeLeft.ToString("F1");

        if (timeLeft <= 0f)
        {
            PlayerGameOver();
        }

        return true;
    }

    void PlayerGameOver()
    {
        gameOver = true;
        gameOverText.SetActive(true);
        playerController.enabled = false;
        Time.timeScale = .1f;
    }
}
