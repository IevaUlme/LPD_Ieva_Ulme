using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishDetection : MonoBehaviour
{

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("You Won!");
        }
    }
}
