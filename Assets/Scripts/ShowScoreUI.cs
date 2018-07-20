using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowScoreUI : MonoBehaviour {

    [SerializeField]
    private Text ScoreText;

    [SerializeField]
    private Text HighScoreText;

    private void Start()
    {
        this.ScoreText = this.transform.Find("ScoreText").gameObject.GetComponent<Text>();
        this.HighScoreText = this.transform.Find("HighScoreText").gameObject.GetComponent<Text>();
    }

    private void OnEnable()
    {
        ScoreManager.Instance.OnScoreChange += SetScore;
        ScoreManager.Instance.OnHighScoreChange += SetHighScore;
    }

    private void OnDisable()
    {
        ScoreManager.Instance.OnScoreChange -= SetScore;
        ScoreManager.Instance.OnHighScoreChange -= SetHighScore;
    }

    public void SetScore(int score)
    {
        this.ScoreText.text = "Score: " + score.ToString();
    }

    public void SetHighScore(int highScore)
    {
        this.HighScoreText.text = "Best Score: " + highScore.ToString();
    }
}
