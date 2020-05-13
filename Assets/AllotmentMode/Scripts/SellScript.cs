using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SellScript : MonoBehaviour
{

    public Button sellBatch;
    public Button sellOne;

    public string chaseMode;

    private int inputCarrotAmount;
    public int currentCarrotAmount;
    private bool batch;
    private bool one;
    public GameObject fadeBackground;
    public InputField input;
    private int moneyToAdd;
    public int currentMoney;

    public bool caught;

    public float caughtThresholdHigh;
    public float caughtThresholdLow;

    private float delayTime;
    private bool startDelay;
    private StatsScript theStatsManager;

    public GameObject fadeError;

    private int securityBonus;


    public GameObject sellHelpScreen;

    private int profitsToDeduct;

    private int currentMoneyCaught;

    private bool shouldDeduct;

    // if the timer is on the player pref is 0 and buttons should be not interactable otherwise they should be interactable
    private void buttonInteractableStatus() {
        
        if (PlayerPrefs.GetInt("sellBatchActive") == 0)
        {
            sellBatch.interactable = false;

        }
        else {
            sellBatch.interactable = true;
        }
        if (PlayerPrefs.GetInt("sellOneActive") == 0)
        {

            sellOne.interactable = false;

        }
        else
        {
            sellOne.interactable = true;
        }


    }
    

    public void sellHelpOkButton() {
        sellHelpScreen.SetActive(false);
    }

    public void sellHelpButton() {

        sellHelpScreen.SetActive(true);

    }

    public void SellBatchButton() {
        
        batch = true;
        fadeBackground.SetActive(true);

    }

    public void SellOneButton()
    {

        one = true;
        fadeBackground.SetActive(true);

    }

    public void ConfirmButton() {
        inputCarrotAmount = int.Parse(input.text);
        currentCarrotAmount = PlayerPrefs.GetInt("Carrots");
        
        if (inputCarrotAmount <= currentCarrotAmount)
        {


            if (batch == true)
            {

                SellBatch(inputCarrotAmount, 4, caughtThresholdHigh + securityBonus);
                batch = false;
            }
            if (one == true)
            {

                startDelay = true;
                delayTime = inputCarrotAmount * 1;
                SellOne(inputCarrotAmount, 10, caughtThresholdLow + securityBonus);
                one = false;
                startDelay = false;
            }


            fadeBackground.SetActive(false);
        }
        else {
            fadeError.SetActive(true);
            
            caught = false;


        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
        theStatsManager = FindObjectOfType<StatsScript>();

        batch = false;
        one = false;
        caught = false;
        startDelay = false;
        

    }

    private void SellBatch(int carrotAmount, int multiplier, float caughtThreshold) {

        currentCarrotAmount = PlayerPrefs.GetInt("Carrots");

        currentCarrotAmount -= carrotAmount;
        PlayerPrefs.SetInt("Carrots", currentCarrotAmount);

        moneyToAdd = carrotAmount * multiplier;
        currentMoney = PlayerPrefs.GetInt("Money");

        currentMoney += moneyToAdd;

        PlayerPrefs.SetInt("Money", currentMoney);


        if (Random.Range(0f, 100f) > caughtThreshold)
        {


            caught = true;

        }
        else {
            caught = false;
        }
        Debug.Log("Caught: " + caught);


       
        batch = false;

        if (caught == true)
        {
            if (inputCarrotAmount > 1) {

                profitsToDeduct = moneyToAdd / 2;


                currentMoneyCaught = PlayerPrefs.GetInt("Money");

                currentMoneyCaught = currentMoneyCaught - profitsToDeduct;

                PlayerPrefs.SetInt("Money", currentMoneyCaught);

            }
            

            Application.LoadLevel(chaseMode);
        }



    }

    private void SellOne(int carrotAmount, int multiplier, float caughtThreshold) {

        currentCarrotAmount = PlayerPrefs.GetInt("Carrots");

        currentCarrotAmount -= carrotAmount;
        

        moneyToAdd = carrotAmount * multiplier;
        currentMoney = PlayerPrefs.GetInt("Money");

        currentMoney += moneyToAdd;

        
        

        if (Random.Range(0f, 100f) > caughtThreshold)
        {


            caught = true;

        }
        else
        {
            caught = false;
        }
        Debug.Log("Caught: " + caught);


        //start the plantNoHarvest process in stats manager script
        theStatsManager.sell = true;

        // set the delay within stats script to the delay set by the confirm button
        theStatsManager.timer = delayTime;

        // start the delay
        theStatsManager.startDelay = startDelay;


        PlayerPrefs.SetInt("TempCarrotSellAmount", currentCarrotAmount);
        PlayerPrefs.SetInt("TempMoneyAmount", currentMoney);





        one = false;


        if (caught == true)
        {
            if (inputCarrotAmount > 1)
            {

                profitsToDeduct = moneyToAdd / 2;


                currentMoneyCaught = PlayerPrefs.GetInt("Money");

                currentMoneyCaught = currentMoneyCaught - profitsToDeduct;

                PlayerPrefs.SetInt("Money", currentMoneyCaught);

            }

            Application.LoadLevel(chaseMode);
        }


    }


    public void OkButton() {
        
        fadeError.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        securityBonus = PlayerPrefs.GetInt("SecurityBonus");

        buttonInteractableStatus();
        
    }
}
