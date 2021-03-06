using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public Text scoreText;
    public Text TimerText;
    public bool BonusActivated = false;

    private int score = 0;
    private float time = 0f;

    private void Awake()
    {
        instance = this;
    }

    void Update()
    {
        scoreText.text = score.ToString() + " POINTS";
        if (BonusActivated)
        {
            time -= Time.deltaTime;
            if (time <= 0)
            {
                BonusActivated = false;
                TimerText.text = "";
            }
            else
                TimerText.text = (time).ToString("0") + "s left";
        }
    }

    public void AddPoint()
    {
        score++;
        if (BonusActivated) 
        {
            score++;
        }
    }
    public void SetTime(float time)
    {
        this.time = time;
    }
    public float GetScore()
    {
        return score;
    }
}
