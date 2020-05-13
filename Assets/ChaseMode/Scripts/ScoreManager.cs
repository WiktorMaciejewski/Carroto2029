using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText;
    public Text highScoreText;


    public float scoreCount;
    public float highScoreCount;


    public float pointsPerSecond;

    public bool scoreIncreasing;

    
    


    // Start is called before the first frame update
    // check if there is a high score value already stored, if there is then assign the highScoreCount variable that value
    void Start()
    {
        if (PlayerPrefs.HasKey("HighScore")) {

            highScoreCount = PlayerPrefs.GetFloat("HighScore");

        } 
        
    }






    // Update is called once per frame
    // when scoreIncreasing is true then the score increases by pointsPerSecond * time
    // if the score is greater than the highscore then that score becomes the high score
    // these values then get passed into the text boxes that are relevan to them
    void Update()
    {

        if (scoreIncreasing == true) { 

            scoreCount += pointsPerSecond * Time.deltaTime;

        }
        if (scoreCount > highScoreCount) {

            highScoreCount = scoreCount;
            PlayerPrefs.SetFloat("HighScore", highScoreCount);


        }
        

        
        scoreText.text = "Score: " + Mathf.Round(scoreCount);
        highScoreText.text = "High Score: " + Mathf.Round(highScoreCount);





        

    }
    // a function that adds an integer value to the score
    public void AddScore(int pointsToAdd) {
        

        pointsToAdd = pointsToAdd * 2;
        
        scoreCount += pointsToAdd;

    }
}
