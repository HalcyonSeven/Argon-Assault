using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreBoard : MonoBehaviour
{
    private int score;
    private TMP_Text scoreText;

    private void Start()
    {
        scoreText = GetComponent<TMP_Text>();
        scoreText.text = "Start";
    }

    public void UpdateScore(int scoreToIncrease)
    {
        score += scoreToIncrease;
        scoreText.text = score.ToString();
    }
}
