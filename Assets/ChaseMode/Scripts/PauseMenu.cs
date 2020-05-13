using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public string mainMenuLevel;

    // link to the pauseMenu game object in unity
    public GameObject pauseMenu;


    // sets the time scale to 0 so that game stops and activates the pause menu Game Object
    public void pauseGame() {

        Time.timeScale = 0f;
        pauseMenu.SetActive(true);    
    }
    // sets the time scale back to normal
    // deactivates the pause menu game object
    public void resumeGame() {

        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
    }

    // resets the time scale back to normal
    // de-activates the pause menu
    // resets the game by using the GameManager Reset() method
    // loads the overviewScene from Allotment Mode
    public void restartGame()
    {
        
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
        FindObjectOfType<GameManager>().Reset();
        Application.LoadLevel(mainMenuLevel);


    }

    

}
