using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuitBuuton : MonoBehaviour
{

    public void QuitGame()
    {
        Application.Quit(); // no builda 
        UnityEditor.EditorApplication.isPlaying = false; // no simulatora
    }
}


