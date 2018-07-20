using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager
{
    private static ScoreManager _instance;
    public static ScoreManager Instance
    {
        get
        {
            if(_instance == null)
            {
                _instance = new ScoreManager();
            }
            return _instance;
        }
    }

    public int Score
    {
        private set;
        get;
    }

    public int HighScore
    {
        private set;
        get;
    }

    public event System.Action<int> OnScoreChange;
    public event System.Action<int> OnHighScoreChange;

    public void AddScore(int score)
    {
        this.Score += score;
        this.OnScoreChange(this.Score);
        if(this.Score > this.HighScore)
        {
            this.HighScore = this.Score;
            this.OnHighScoreChange(this.HighScore);
        }
    }
}
