using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class test : MonoBehaviour
{
    public Text Score;
    // Start is called before the first frame update
    void Start()
    {
        int score = 0;
        int.TryParse(ScoreManager.instance.scoreText.text[0].ToString(),out score);
        if(score == 0)
        {
            Score.text = "Not Good, you Picked up " + score + " Pieces of trash";
        }
        if (score == 1)
        {
            Score.text = "Not Good, you Picked up " + score + " Piece of trash";
        }
        else
        {
            Score.text = "Congratulations, you Picked up " + score + " Pieces of trash";
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
