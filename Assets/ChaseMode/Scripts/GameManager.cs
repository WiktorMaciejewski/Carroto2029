using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Transform platformGenerator;
    private Vector3 platformStartPoint;

    public Player_Controller player;

    private Vector3 playerStartPoint;

    private PlatformDestroyer[] platformList;

    private ScoreManager scoreManager;

   
    public DeathMenu deathScreen;

    private int currentExperience;

    // Start is called before the first frame update
    // assign the start position of the platformGenrator and player to the StartPoint variables
    // assign the ScoreManager game object to the relevant variable
    void Start()
    {

        
        platformStartPoint = platformGenerator.position;
        playerStartPoint = player.transform.position;

        scoreManager = FindObjectOfType<ScoreManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    // this gets run when the player dies, it stops the score from increasing,
    // adds the Chase Mode score to current experience for Allotment Mode,
    // deasctivates player and shows them the deathScreen
    public void restartGame() {

        
        scoreManager.scoreIncreasing = false;

        currentExperience = PlayerPrefs.GetInt("CurrentExperience");
        currentExperience = currentExperience + Mathf.RoundToInt(scoreManager.scoreCount);
        PlayerPrefs.SetInt("CurrentExperience", currentExperience);

        
        player.gameObject.SetActive(false);

        
        deathScreen.gameObject.SetActive(true);


        


    }
    // this deactivates the deathScreen, sets all objects with PlatformDestroyer attached to them as inactive,
    // resets the start position for the player and platformGenerator,
    // then sets the player as active, resets the score to 0 and inistiates the score to increase again
    public void Reset() {


        
        deathScreen.gameObject.SetActive(false);

        
        platformList = FindObjectsOfType<PlatformDestroyer>();

        
        for (int i = 0; i < platformList.Length; i++)
        {

            platformList[i].gameObject.SetActive(false);

        }

        

        player.transform.position = playerStartPoint;

        platformGenerator.position = platformStartPoint;

       
        player.gameObject.SetActive(true);

        scoreManager.scoreCount = 0;
   
        scoreManager.scoreIncreasing = true;

        


    }



}
