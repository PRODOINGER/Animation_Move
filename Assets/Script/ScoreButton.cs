using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class ScoreButton : MonoBehaviour
{

    public Button scoreButton;
    public int score = 0;
    public Action<int> OnScoreChanged;

    void Awake()
    {
        scoreButton = GetComponent<Button>();
        scoreButton.onClick.AddListener(PointUp);
    }

    void PointUp()
    {
        score += 1;
        // 점수가 올라감
        OnScoreChanged?.Invoke(score);
    }
}

