using System;
using System.Security.Cryptography;
using UnityEngine;

public class Trash : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        ScoreManager.instance.AddPoint();
        print("Trash pickup up!");
        Destroy(gameObject);
    }
}
