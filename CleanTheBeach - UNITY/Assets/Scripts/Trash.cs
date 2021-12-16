using System;
using System.Security.Cryptography;
using UnityEngine;

public class Trash : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        
        print("Trash pickup up!");
        Destroy(gameObject);
    }
}
