using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreText : MonoBehaviour
{
    public ScoreButton ScoreButton;
    public TextMeshProUGUI scoreText;
    // Start is called before the first frame update
    void Awake()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
        ScoreButton.OnScoreChanged += RefreshUI;
    }

    // Update is called once per frame
    void RefreshUI(int newScore)
    {
        scoreText.text = "Score:" + newScore;
    }
}
