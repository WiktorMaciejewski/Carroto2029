using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadUpgradeImageScript : MonoBehaviour
{

    public GameObject[] upgradeImages;

    private int upgradeCounter;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


        upgradeCounter = PlayerPrefs.GetInt("UpgradeLevel");

        for (int i = 0; i < upgradeImages.Length; i++) {

            upgradeImages[i].SetActive(false);


            if (i == upgradeCounter) {

                upgradeImages[upgradeCounter].SetActive(true);
               

            }
            


        }


        
    }
}
