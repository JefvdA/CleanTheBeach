using System;
using System.Security.Cryptography;
using UnityEngine;

public class Trash : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        print("TEST");
        if (!other.CompareTag("Player")) return;

        ScoreManager.instance.AddPoint();
        print("Trash pickup up!");
        //Destroy(gameObject);
        transform.position = new Vector3(UnityEngine.Random.Range(5, 45), 4.5f, UnityEngine.Random.Range(0, 24));
    }
}
