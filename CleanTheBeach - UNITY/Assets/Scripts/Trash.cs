using System;
using System.Security.Cryptography;
using UnityEngine;

public class Trash : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        //print("TEST");
        if (!other.CompareTag("Player")) return;

        ScoreManager.instance.AddPoint();
        //print("Trash pickup up!");
        Destroy(gameObject.transform.parent.gameObject);
    }
}
