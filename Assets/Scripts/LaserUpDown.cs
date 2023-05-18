using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserUpDown : MonoBehaviour
{
    [SerializeField] float travelHeight = 2f;
    float origY;

    // Start is called before the first frame update
    void Start()
    {
        origY = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(
            transform.position.x,
            origY + 1 + Mathf.Sin(Time.realtimeSinceStartup) * travelHeight,
            transform.position.z
        );
    }
}
