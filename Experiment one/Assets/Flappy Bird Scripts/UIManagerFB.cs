using System;
using UnityEngine;
using UnityEngine.UI;

public class UIManagerFB : MonoBehaviour
{
    private Text _scoreText;
    private int _score = 0;
    private bool _isPlayerDead = false;
    void Start()
    {
        _scoreText = GameObject.Find("Canvas").GetComponentInChildren<Text>();

        ScoreFB.scoreVal += UpdateScore;

        player.onDead += IsPlayerDead;
    }

    void UpdateScore(object sender, EventArgs e)
    {
         if(!_isPlayerDead)
           _score++;

        _scoreText.text = "Score: " + _score.ToString();
    }

    void IsPlayerDead()
    {
        _isPlayerDead = true;
    }
}
