using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public Text scoreText;

    private int score = 0;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update

    void Update()
    {
        scoreText.text = score.ToString() + " POINTS";
    }

    public void AddPoint()
    {
        score++;
    }
}
