using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FinishDetection : MonoBehaviour
{
    private GameObject player;
    private GameObject cameraObj;
    private PlayerMovement movementScript;
    private ThirdPersonCam cameraScript;
    private CinemachineFreeLook cameraComp;


    private void Start()
    {
        cameraObj = GameObject.Find("PlayerCam");
        player = GameObject.FindGameObjectWithTag("Player");
        movementScript = player.GetComponent<PlayerMovement>();
        cameraScript = cameraObj.GetComponent<ThirdPersonCam>();
        cameraComp = cameraObj.GetComponent<CinemachineFreeLook>();
    }
        
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            movementScript.enabled = false;
            cameraScript.enabled = false;
            cameraComp.enabled = false;

            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            Debug.Log("You Won!");
 
        }
    }
}
