using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LaserDetection : MonoBehaviour
{
    public Renderer laserRend;
    public Color laserColor;

    private GameObject player;
    private GameObject cameraObj;
    private PlayerMovement movementScript;
    private ThirdPersonCam cameraScript;
    private CinemachineFreeLook cameraComp;

    // Start is called before the first frame update
    void Start()
    {
        cameraObj = GameObject.Find("PlayerCam");
        player = GameObject.FindGameObjectWithTag("Player");
        movementScript = player.GetComponent<PlayerMovement>();
        cameraScript = cameraObj.GetComponent<ThirdPersonCam>();
        cameraComp = cameraObj.GetComponent<CinemachineFreeLook>();
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
            movementScript.enabled = false;
            cameraScript.enabled = false;
            cameraComp.enabled = false;

            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            Debug.Log("You got detected!");
        }
    }

    
}
