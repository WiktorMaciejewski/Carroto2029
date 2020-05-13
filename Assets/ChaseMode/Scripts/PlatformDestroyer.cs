using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformDestroyer : MonoBehaviour
{

    public GameObject platformDestructionPoint;

    // Start is called before the first frame update
    // assign any game object by the name of "PlatformDestructor" to platformDestructionPoint
    void Start()
    {
        
        platformDestructionPoint = GameObject.Find("PlatformDestructor");
    }

    // Update is called once per frame
    // if the x position of the current platform is less than 
    // the x position of the destruction point then deactivate the gameObject
    void Update()
    {

        
        if (transform.position.x < platformDestructionPoint.transform.position.x) {

            

            gameObject.SetActive(false);

        }
    }
}
