using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{

    public string GameEnded;

    public float timeStart = 60;
    public Text textBox;

    // Start is called before the first frame update
    void Start()
    {
        textBox.text = timeStart.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (timeStart <= 0)
            SceneManager.LoadScene(GameEnded);
        timeStart -= Time.deltaTime;
        textBox.text = Mathf.Round(timeStart).ToString();
    }
}
