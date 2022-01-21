using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public string load;
    public float timeLeft = 60f;
    public Text textBox;

    // Update is called once per frame
    void Update()
    {
        timeLeft -= Time.deltaTime;
        textBox.text = (timeLeft).ToString("0");
        if (timeLeft <= 0)
        {
            timeLeft = 0;
            Cursor.visible = true;
            SceneManager.LoadScene(load);
        }
    }
}
