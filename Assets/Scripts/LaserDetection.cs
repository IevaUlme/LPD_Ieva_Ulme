using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserDetection : MonoBehaviour
{
    public Renderer laserRend;
    public Color laserColor;

    // Start is called before the first frame update
    void Start()
    {

        Color laserColor = new Color(200, 0, 0, 0.3f);
        laserRend = GetComponent<Renderer>();
        laserRend.material.color = laserColor;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter (Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("You got detected!");
        }
    }

    
}
