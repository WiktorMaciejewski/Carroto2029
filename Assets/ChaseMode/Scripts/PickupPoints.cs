using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupPoints : MonoBehaviour
{
    public int scoreToAdd;

    private ScoreManager theScoreManager;


    private AudioSource carrotSound;

    private int currentCarrotAmount;

    
    // Start is called before the first frame update
    // the score manager is assigned the relevant object
    // the carrot sound audio clip is linked to the variable
    void Start()
    {

        
        theScoreManager = FindObjectOfType<ScoreManager>();

        
        carrotSound = GameObject.Find ("carrotSound").GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // when the player collides with a carrot object the game object disappears, 
    // extra points are added to the score counting value and the amount of carrots available to the player increments by one
    // Also it checks whether the sound is playing already, if it is then restart it if it isn't then just play the sound
    // Done to avoid the audio clip playing more than once at a time
    private void OnTriggerEnter2D(Collider2D other)
    {

         
        if (other.gameObject.name == "Player") {

            theScoreManager.AddScore(scoreToAdd);
            gameObject.SetActive(false);

            currentCarrotAmount = PlayerPrefs.GetInt("Carrots");
            currentCarrotAmount++;
            PlayerPrefs.SetInt("Carrots", currentCarrotAmount);

            
            if (carrotSound.isPlaying) {

                carrotSound.Stop();
                carrotSound.Play();

            }
            
            else { 
            
            carrotSound.Play();
            }
        }
    }

}
