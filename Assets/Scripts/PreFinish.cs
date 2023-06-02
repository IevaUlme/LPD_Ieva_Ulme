using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreFinish : MonoBehaviour
{
    public MeshRenderer finish;
    bool isTriggered = false;

    float opacity = 0f;
    float targetOpacity = 150f;
    float speed = 20f;

    void Update()
    {
        if (isTriggered)
        {
            opacity = Mathf.Lerp(opacity, targetOpacity, speed * Time.deltaTime);

            Color color = finish.material.color;
            color.a = opacity / 255f;

            finish.material.color = color;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isTriggered = true;
            Debug.Log("TEEEEEEEST");
        }
    }
}
