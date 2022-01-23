using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public Text scoreText;

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
        time -= Time.deltaTime;
        if (time <= 0)
        {
            BonusActivated = false;
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
}
