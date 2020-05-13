using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsScript : MonoBehaviour
{
    public int moneyAmount;
    public int seedsAmount;
    public int level;
    public int currentExperienceAmount;
    public int nextLevelExperienceAmount;
    public int carrotAmount;
    public float timer;


    private int tempCarrotPlantAmount;
    private int tempSeedsAmount;
    private int tempMoneyAmount;
    private int tempCarrotSellAmount;


    public bool startDelay;
    private PlantScript thePlantManager;
    private SellScript theSellManager;
    public bool plant;
    public bool sell;
    private int nurtureCounter;
    private int nurtureValue0;
    private int nurtureValue1;
    private int nurtureValue2;
    private int nurtureValue3;
    private int nurtureValue4;
    private int nurtureValue5;
    private int i;

    private int currentExperienceLevelCheck;
    private int nextLevelExperienceLevelCheck;
    private int currentLevel;


    // checks if the experience for the next level has been met, increases the level by one and increases the boundry for next level by 1000
    private void checkLevel(){

        currentExperienceLevelCheck = PlayerPrefs.GetInt("CurrentExperience");
        nextLevelExperienceLevelCheck = PlayerPrefs.GetInt("NextLevelExperience");

        if (currentExperienceLevelCheck >= nextLevelExperienceLevelCheck) {

            currentLevel = PlayerPrefs.GetInt("Level");
            currentLevel++;


            PlayerPrefs.SetInt("Level", currentLevel);
            nextLevelExperienceLevelCheck += 1500;
            PlayerPrefs.SetInt("NextLevelExperience", nextLevelExperienceLevelCheck);


        }

    }


    public void nurtureLevelAdd() {
        nurtureCounter = PlayerPrefs.GetInt("NurtureCounter");

        if (nurtureCounter == 0) {
            nurtureValue0 = 1;

        }
        if (nurtureCounter == 1)
        {
            nurtureValue1 = 1;

        }
        if (nurtureCounter == 2)
        {
            nurtureValue2 = 1;

        }
        if (nurtureCounter == 3)
        {
            nurtureValue3 = 1;

        }
        if (nurtureCounter == 4)
        {
            nurtureValue4 = 1;

        }
        if (nurtureCounter == 5)
        {
            nurtureValue5 = 1;

        }

    }

    public void resetNurtureLevel() {

        PlayerPrefs.SetInt("NurtureCounter",0);

        PlayerPrefs.SetInt("Nurture0", 0);
        PlayerPrefs.SetInt("Nurture1", 0);
        PlayerPrefs.SetInt("Nurture2", 0);
        PlayerPrefs.SetInt("Nurture3", 0);
        PlayerPrefs.SetInt("Nurture4", 0);
        PlayerPrefs.SetInt("Nurture5", 0);


    }
  

    // Start is called before the first frame update
    void Start()
    {


        

        sell = false;
        plant = false;

        //To reset the game state un-comment the line below, save script, run game, exit game and comment line below again
        //PlayerPrefs.DeleteAll();
        setInitialPrefabValues();




    }

    // Update is called once per frame
    void Update()
    {


        checkLevel();

        if (startDelay == true)
        {

        
            timer -= Time.deltaTime;


            PlayerPrefs.SetInt("Timer", Mathf.RoundToInt(timer));

            PlayerPrefs.SetInt("sellBatchActive", 0);
            PlayerPrefs.SetInt("sellOneActive", 0);
            PlayerPrefs.SetInt("plantHarvestActive", 0);
            PlayerPrefs.SetInt("plantNoHarvestActive", 0);

            if (timer <= 0)
            {
                PlayerPrefs.SetInt("sellBatchActive", 1);
                PlayerPrefs.SetInt("sellOneActive", 1);
                PlayerPrefs.SetInt("plantHarvestActive", 1);
                PlayerPrefs.SetInt("plantNoHarvestActive", 1);

                timer = 0;

                if (plant == true) {

                    tempCarrotPlantAmount = PlayerPrefs.GetInt("TempCarrotPlantAmount");
                    tempSeedsAmount = PlayerPrefs.GetInt("TempSeedsAmount");

                    thePlantManager = FindObjectOfType<PlantScript>();
                    PlayerPrefs.SetInt("Carrots", tempCarrotPlantAmount);
                    PlayerPrefs.SetInt("Seeds", tempSeedsAmount);
                    

                    PlayerPrefs.SetInt("TempCarrotPlantAmount", 0);
                    PlayerPrefs.SetInt("TempSeedsAmount", 0);

                    plant = false;


                }

                if (sell == true) {
                    tempCarrotSellAmount = PlayerPrefs.GetInt("TempCarrotSellAmount");
                    tempMoneyAmount = PlayerPrefs.GetInt("TempMoneyAmount");

                    theSellManager = FindObjectOfType<SellScript>();
                    PlayerPrefs.SetInt("Carrots", tempCarrotSellAmount);
                    PlayerPrefs.SetInt("Money", tempMoneyAmount);


                    PlayerPrefs.SetInt("TempCarrotSellAmount", 0);
                    PlayerPrefs.SetInt("TempMoneyAmount", 0);

                    sell = false;
                }

                
                PlayerPrefs.SetInt("Timer", Mathf.RoundToInt(timer));
                startDelay = false;
            }
        }

        
        



    }

 

    public void saveStatus()
    {


        PlayerPrefs.SetInt("Money", moneyAmount);
        PlayerPrefs.SetInt("Seeds", seedsAmount);
        PlayerPrefs.SetInt("Level", level);
        PlayerPrefs.SetInt("CurrentExperience", currentExperienceAmount);
        PlayerPrefs.SetInt("NextLevelExperience", nextLevelExperienceAmount);
        PlayerPrefs.SetInt("Carrots", carrotAmount);
        PlayerPrefs.SetInt("Nurture0", nurtureValue0);
        PlayerPrefs.SetInt("Nurture1", nurtureValue1);
        PlayerPrefs.SetInt("Nurture2", nurtureValue2);
        PlayerPrefs.SetInt("Nurture3", nurtureValue3);
        PlayerPrefs.SetInt("Nurture4", nurtureValue4);
        PlayerPrefs.SetInt("Nurture5", nurtureValue5);

        
    }


    public void loadStatus()
    {

        if (PlayerPrefs.HasKey("Money"))
        {

            moneyAmount = PlayerPrefs.GetInt("Money");

        }
        else
        {

            moneyAmount = 1000;
        }

        if (PlayerPrefs.HasKey("Seeds"))
        {

            seedsAmount = PlayerPrefs.GetInt("Seeds");

        }
        else
        {

            seedsAmount = 10;

        }
        if (PlayerPrefs.HasKey("Level"))
        {

            level = PlayerPrefs.GetInt("Level");

        }
        else
        {

            level = 1;

        }
        if (PlayerPrefs.HasKey("CurrentExperience"))
        {

            currentExperienceAmount = PlayerPrefs.GetInt("CurrentExperience");

        }
        else
        {

            currentExperienceAmount = 0;

        }
        if (PlayerPrefs.HasKey("NextLevelExperience"))
        {

            nextLevelExperienceAmount = PlayerPrefs.GetInt("NextLevelExperience");

        }
        else
        {

            nextLevelExperienceAmount = 1000;

        }
        if (PlayerPrefs.HasKey("Carrots"))
        {

            carrotAmount = PlayerPrefs.GetInt("Carrots");

        }
        else
        {

            carrotAmount = 0;

        }
        
        nurtureValue0 = PlayerPrefs.GetInt("Nurture0");
        nurtureValue1 = PlayerPrefs.GetInt("Nurture1");
        nurtureValue2 = PlayerPrefs.GetInt("Nurture2");
        nurtureValue3 = PlayerPrefs.GetInt("Nurture3");
        nurtureValue4 = PlayerPrefs.GetInt("Nurture4");
        nurtureValue5 = PlayerPrefs.GetInt("Nurture5");


    }


   

    // set initital prefab values the first time the program is run to avoid nullObjectReference errors
    private void setInitialPrefabValues() {

        if (PlayerPrefs.HasKey("Money") == false) {

            PlayerPrefs.SetInt("Money", 1000);

        }
        if (PlayerPrefs.HasKey("Seeds") == false)
        {

            PlayerPrefs.SetInt("Seeds", 10);

        }
        if (PlayerPrefs.HasKey("NurtureCounter") == false)
        {

            PlayerPrefs.SetInt("NurtureCounter", 0);

        }
        if (PlayerPrefs.HasKey("UpgradeLevel") == false)
        {

            PlayerPrefs.SetInt("UpgradeLevel", 0);

        }
        if (PlayerPrefs.HasKey("plantHarvestActive") == false)
        {

            PlayerPrefs.SetInt("plantHarvestActive", 1);

        }
        if (PlayerPrefs.HasKey("plantNoHarvestActive") == false)
        {

            PlayerPrefs.SetInt("plantNoHarvestActive", 1);

        }
        if (PlayerPrefs.HasKey("Carrots") == false)
        {

            PlayerPrefs.SetInt("Carrots", 0);

        }
        if (PlayerPrefs.HasKey("FlowerRateBonus") == false)
        {

            PlayerPrefs.SetInt("FlowerRateBonus", 0);

        }
        if (PlayerPrefs.HasKey("TempCarrotPlantAmount") == false)
        {

            PlayerPrefs.SetInt("TempCarrotPlantAmount", 0);

        }
        if (PlayerPrefs.HasKey("TempSeedsAmount") == false)
        {

            PlayerPrefs.SetInt("TempSeedsAmount", 0);

        }
        if (PlayerPrefs.HasKey("sellBatchActive") == false)
        {

            PlayerPrefs.SetInt("sellBatchActive", 1);

        }
        if (PlayerPrefs.HasKey("sellOneActive") == false)
        {

            PlayerPrefs.SetInt("sellOneActive", 1);

        }
        if (PlayerPrefs.HasKey("TempCarrotSellAmount") == false)
        {

            PlayerPrefs.SetInt("TempCarrotSellAmount", 0);

        }
        if (PlayerPrefs.HasKey("TempMoneyAmount") == false)
        {

            PlayerPrefs.SetInt("TempMoneyAmount", 0);

        }
        if (PlayerPrefs.HasKey("SecurityBonus") == false)
        {

            PlayerPrefs.SetInt("SecurityBonus", 0);

        }
        if (PlayerPrefs.HasKey("CurrentExperience") == false)
        {

            PlayerPrefs.SetInt("CurrentExperience", 0);

        }
        if (PlayerPrefs.HasKey("NextLevelExperience") == false)
        {

            PlayerPrefs.SetInt("NextLevelExperience", 1000);

        }
        if (PlayerPrefs.HasKey("Level") == false)
        {

            PlayerPrefs.SetInt("Level", 1);

        }
        if (PlayerPrefs.HasKey("Nurture0") == false)
        {

            PlayerPrefs.SetInt("Nurture0", 0);

        }
        if (PlayerPrefs.HasKey("Nurture1") == false)
        {

            PlayerPrefs.SetInt("Nurture1", 0);

        }
        if (PlayerPrefs.HasKey("Nurture1") == false)
        {

            PlayerPrefs.SetInt("Nurture1", 0);

        }
        if (PlayerPrefs.HasKey("Nurture2") == false)
        {

            PlayerPrefs.SetInt("Nurture2", 0);

        }
        if (PlayerPrefs.HasKey("Nurture3") == false)
        {

            PlayerPrefs.SetInt("Nurture3", 0);

        }
        if (PlayerPrefs.HasKey("Nurture4") == false)
        {

            PlayerPrefs.SetInt("Nurture4", 0);

        }
        if (PlayerPrefs.HasKey("Nurture5") == false)
        {

            PlayerPrefs.SetInt("Nurture5", 0);

        }
        if (PlayerPrefs.HasKey("Timer") == false)
        {

            PlayerPrefs.SetInt("Timer", 0);

        }
        if (PlayerPrefs.HasKey("soilActive") == false)
        {

            PlayerPrefs.SetInt("soilActive", 1);

        }
        if (PlayerPrefs.HasKey("woodenActive") == false)
        {

            PlayerPrefs.SetInt("woodenActive", 1);

        }
        if (PlayerPrefs.HasKey("sprinklersActive") == false)
        {

            PlayerPrefs.SetInt("sprinklersActive", 1);

        }
        if (PlayerPrefs.HasKey("dogActive") == false)
        {

            PlayerPrefs.SetInt("dogActive", 1);

        }
        if (PlayerPrefs.HasKey("greenhouseActive") == false)
        {

            PlayerPrefs.SetInt("greenhouseActive", 1);

        }
        if (PlayerPrefs.HasKey("brickActive") == false)
        {

            PlayerPrefs.SetInt("brickActive", 1);

        }
        if (PlayerPrefs.HasKey("lightsActive") == false)
        {

            PlayerPrefs.SetInt("lightsActive", 1);

        }
        if (PlayerPrefs.HasKey("guardActive") == false)
        {

            PlayerPrefs.SetInt("guardActive", 1);

        }
        if (PlayerPrefs.HasKey("thermostatActive") == false)
        {

            PlayerPrefs.SetInt("thermostatActive", 1);

        }
        if (PlayerPrefs.HasKey("camerasActive") == false)
        {

            PlayerPrefs.SetInt("camerasActive", 1);

        }


    }




}
