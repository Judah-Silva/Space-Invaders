using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PointManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;
    
    // Start is called before the first frame update
    void Start()
    {
        Enemy.OnEnemyDeath += EnemyOnOnEnemyDeath;

    }

    void EnemyOnOnEnemyDeath(int pointworth)
    {
        string[] words = scoreText.text.Split(' ');
        int score = int.Parse(words[1]);
        score += pointworth;
        string scoreString = score.ToString();
        while (scoreString.Length < 4)
        {
            scoreString = '0' + scoreString;
        }
        scoreText.text = $"SCORE: {scoreString}";

        if (score > int.Parse(highScoreText.text.Split(' ')[2]))
        {
            highScoreText.text = $"HIGH SCORE: {scoreString}";
        }
    }

    public void ResetScore()
    {
        scoreText.text = "SCORE: 0000";
    }
}
