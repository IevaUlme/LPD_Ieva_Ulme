using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] Text counterText;
    public float seconds, minutes;
    
    private void Start()
    {
        
        counterText = GetComponent<Text>();
    }

    private void Update()
    {
        minutes = (int)(Time.time / 60f);
        seconds = (int)(Time.time % 60f);
        string text = minutes.ToString() + ":" + seconds.ToString();
        counterText.text = text;
    }
}
