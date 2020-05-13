using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Controller : MonoBehaviour
{
    public Player_Controller player;
    private Vector3 previousPosition;
    private float distance;





    // Start is called before the first frame update
    // assign the Player_Controller object to player variable
    // assign the players transform co-ordinates to previousPosition
    void Start()
    {
        
        player = FindObjectOfType<Player_Controller>();

        previousPosition = player.transform.position;
    }

    // Update is called once per frame
    // make the camera move along the x axis by constantly calculating the distance between 
    // the players position in the previous frame and the current frame and applying this distance to the position of the camera
    void Update()
    {

         
        distance = player.transform.position.x - previousPosition.x;
        transform.position = new Vector3(transform.position.x + distance, transform.position.y, transform.position.z);
        previousPosition = player.transform.position;



    }
}
