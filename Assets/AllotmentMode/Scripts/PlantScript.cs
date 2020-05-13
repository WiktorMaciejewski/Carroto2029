using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlantScript : MonoBehaviour
{


    public Button plantHarvest;
    public Button plantNoHarvest;

    public Text timer;
    public float flowerSuccessThreshold;
    public float seedSuccessThreshold;

    private bool flowered;

    public int carrotAmount;

    private int carrotsToAddAmount;

    private int wasteAmount;

    public InputField input;

    private int seedsAmount;
    private bool harvest;

    public GameObject fade;
    public GameObject errorMessage;
    public GameObject fade2;

    public int currentSeedsAmount;

    private int seedsToAdd;
    private int seedsToAddCounter;


    private bool startDelay;
    private float timeDelay;

    

    private StatsScript theStatsManager;


    private int addToThreshold;
    private int flowerRateBonus;



    public GameObject plantHelpScreen;






    public void plantHelpOkButton()
    {
        plantHelpScreen.SetActive(false);
    }

    public void plantHelpButton()
    {

        plantHelpScreen.SetActive(true);

    }


   



    // Start is called before the first frame update
    void Start()
    {
        
        carrotAmount = PlayerPrefs.GetInt("Carrots");
        currentSeedsAmount = PlayerPrefs.GetInt("Seeds");
        
        startDelay = false;
        theStatsManager = FindObjectOfType<StatsScript>();


    }

    // Update is called once per frame
    void Update()
    {
        flowerRateBonus = PlayerPrefs.GetInt("FlowerRateBonus");

        buttonInteractableStatus();
    }


    // plant without harvesting button
    public void PlantNoHarvestButton() {


        harvest = false;
        fade.SetActive(true);
    }

    // plant with harvesting button 
    public void PlantHarvestButton()
    {


        harvest = true;
        fade.SetActive(true);
    }

    // confirm the amount of seeds to use for plant operation button
    public void ConfirmButton() {

        // add the benefits of soil nurture to the flower and seed success thresholds
        addToThreshold = 5 * PlayerPrefs.GetInt("NurtureCounter");
        flowerSuccessThreshold = flowerSuccessThreshold + addToThreshold;
        seedSuccessThreshold = seedSuccessThreshold + addToThreshold;



        seedsAmount = int.Parse(input.text);
        if (seedsAmount <= currentSeedsAmount)
        {
            if (harvest == true)
            {
                timeDelay = 2 * seedsAmount;

                
                startDelay = true;

                ProcessPlantHarvest(seedsAmount);
            }
            if (harvest == false)
            {
                timeDelay = 1 * seedsAmount;
                
                startDelay = true;

                ProcessPlantNoHarvest(seedsAmount);

                

            }

        }
        else {
            errorMessage.SetActive(true);
            fade2.SetActive(true);

        }


        theStatsManager.resetNurtureLevel();

        //reset the thresholds back to original value
        seedSuccessThreshold = seedSuccessThreshold - addToThreshold;
        flowerSuccessThreshold = flowerSuccessThreshold - addToThreshold;

        fade.SetActive(false);

    }

    // process plant without harvesting seeds operation
    public void ProcessPlantNoHarvest(int seedAmount) {

        
        for (int i = 0; i < seedAmount; i++)
        {
            if (Random.Range(0f, 100f) < flowerSuccessThreshold + flowerRateBonus)
            {

                flowered = true;
            }
            else
            {
                flowered = false;
            }

            if (flowered == true)
            {

                carrotsToAddAmount++;
            }
            if (flowered == false) {

                wasteAmount++;
            }
        }

        // take away the seeds that the user wants to plant from the total seed amount
        currentSeedsAmount -= seedAmount;
        // add the carrots that have flowered to the total carrot amount
        carrotAmount += carrotsToAddAmount;

        

        //start the plantNoHarvest process in stats manager script
        theStatsManager.plant = true;

        // set the delay within stats script to the delay set by the confirm button
        theStatsManager.timer = timeDelay;

        // start the delay
        theStatsManager.startDelay = startDelay;


        PlayerPrefs.SetInt("TempCarrotPlantAmount", carrotAmount);
        PlayerPrefs.SetInt("TempSeedsAmount", currentSeedsAmount);

        resetValues();
    }

    // process the plant with harvesting seeds operation
    public void ProcessPlantHarvest(int seedAmount)
    {


        for (int i = 0; i < seedAmount; i++)
        {
            if (Random.Range(0f, 100f) <= flowerSuccessThreshold + flowerRateBonus)
            {

                flowered = true;
            }
            else
            {
                flowered = false;
            }

            if (flowered == true)
            {
                if (Random.Range(0f, 100f) <= seedSuccessThreshold) {
                    seedsToAdd = Mathf.RoundToInt(Random.Range(0.5f, 3.4f));

                    seedsToAddCounter += seedsToAdd;
                }
                carrotsToAddAmount++;
            }
            if (flowered == false)
            {

                wasteAmount++;
            }
        }
        carrotAmount += carrotsToAddAmount;
        currentSeedsAmount -= seedAmount;
        currentSeedsAmount += seedsToAddCounter;

        //start the plantNoHarvest process in stats manager script
        theStatsManager.plant = true;

        // set the delay within stats script to the delay set by the confirm button
        theStatsManager.timer = timeDelay;

        // start the delay
        theStatsManager.startDelay = startDelay;


        PlayerPrefs.SetInt("TempCarrotPlantAmount", carrotAmount);
        PlayerPrefs.SetInt("TempSeedsAmount", currentSeedsAmount);


        resetValues();
        
    }

    // the error ok button
    public void OkButton() {
        errorMessage.SetActive(false);
        fade2.SetActive(false);

    }


    public void resetValues() {

        // reset values
        carrotsToAddAmount = 0;
        wasteAmount = 0;

        seedsToAddCounter = 0;
        seedsToAdd = 0;
        startDelay = false;

    }

    // if the timer is on, the player pref is 0 and buttons should be not interactable otherwise they should be interactable
    private void buttonInteractableStatus()
    {

        if (PlayerPrefs.GetInt("plantHarvestActive") == 0)
        {
            plantHarvest.interactable = false;

        }
        else
        {
            plantHarvest.interactable = true;
        }
        if (PlayerPrefs.GetInt("plantNoHarvestActive") == 0)
        {

            plantNoHarvest.interactable = false;

        }
        else
        {
            plantNoHarvest.interactable = true;
        }


    }

}
