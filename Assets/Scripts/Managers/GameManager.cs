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
            GameOver();
        }

        return true;
    }

    void GameOver()
    {
        gameOver = true;
        gameOverText.SetActive(true);
        playerController.enabled = false;
        Time.timeScale = .1f;
    }
}
