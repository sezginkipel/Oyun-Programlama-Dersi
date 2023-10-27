using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // This is needed to load scenes

public class UIController : MonoBehaviour
{


    public void PlayGame() // This function is called when the Play button is clicked
    {
        SceneManager.LoadScene("Level 1"); // Load the Level 1 scene
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
