using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonus : MonoBehaviour
{
    public float Time = 4f;

    private void OnTriggerEnter(Collider other)
    {
        //print("TEST");
        if (!other.CompareTag("Player")) return;

        ScoreManager.instance.BonusActivated = true;
        ScoreManager.instance.SetTime(Time);
        //print("Trash pickup up!");
        Destroy(gameObject);
    }

}
