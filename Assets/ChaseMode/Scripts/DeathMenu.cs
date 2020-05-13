using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathMenu : MonoBehaviour
{
    public string mainMenuLevel;

    
    public void restartGame() {

        FindObjectOfType<GameManager>().Reset();
        Application.LoadLevel(mainMenuLevel);

    }

    



}
