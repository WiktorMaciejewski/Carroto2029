using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GardeningScript : MonoBehaviour
{

    public GameObject errorScreen;

    private StatusBarManager theStatusBar;
    private StatsScript theStatsManager;
    
    private int nurtureCounter;
    public GameObject fadeNurtureFull;

    private int money;


    public GameObject gardeningHelpScreen;


    public void gardeningHelpOkButton()
    {
        gardeningHelpScreen.SetActive(false);
    }

    public void gardeningtHelpButton()
    {

        gardeningHelpScreen.SetActive(true);

    }
    public void okErrorButton() {

        errorScreen.SetActive(false);

    }

    public void gardeningButton() {

        

        nurtureCounter = PlayerPrefs.GetInt("NurtureCounter");

        if (nurtureCounter < 5)
        {
            // take the money away for paying the gardener
            money = PlayerPrefs.GetInt("Money");
            money = money - 10;

            if (money < 0)
            {


                errorScreen.SetActive(true);
            }
            else
            {
                
                // set the new value for money
                PlayerPrefs.SetInt("Money", money);

                nurtureCounter++;
                PlayerPrefs.SetInt("NurtureCounter", nurtureCounter);
            }
        }
        else {

            fadeNurtureFull.SetActive(true);
            
        }
            

             

    }

    public void okButton() {

        fadeNurtureFull.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        
        theStatsManager = FindObjectOfType<StatsScript>();
        theStatusBar = FindObjectOfType<StatusBarManager>();
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
