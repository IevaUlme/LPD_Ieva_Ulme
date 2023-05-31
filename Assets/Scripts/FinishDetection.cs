using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishDetection : MonoBehaviour
{
    private GameObject player;
    private GameObject cameraObj;
    private PlayerMovement movementScript;
    private ThirdPersonCam cameraScript;
    private CinemachineFreeLook cameraComp;

    private float gameTimer = 0f;
    private bool gameGoing = true;

    private void Start()
    {
        cameraObj = GameObject.Find("PlayerCam");
        player = GameObject.FindGameObjectWithTag("Player");
        movementScript = player.GetComponent<PlayerMovement>();
        cameraScript = cameraObj.GetComponent<ThirdPersonCam>();
        cameraComp = cameraObj.GetComponent<CinemachineFreeLook>();
    }

    private void Update()
    {
        if (gameGoing)
        {
            gameTimer += Time.deltaTime;
        }
    }
        
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            movementScript.enabled = false;
            cameraScript.enabled = false;
            cameraComp.enabled = false;
            gameGoing = false;
            Debug.Log("You Won!");
            Debug.Log("It took you " + gameTimer.ToString() + " to reach finish");
        }
    }
}
