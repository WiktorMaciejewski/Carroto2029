using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UpgradesScript : MonoBehaviour
{

    public GameObject buyUpgradesScreen;
    public GameObject buySeedsScreen;

    public Button soilButton;
    public Button sprinklersButton;
    public Button greenhouseButton;
    public Button lightsButton;
    public Button thermostatButton;
    public Button woodenFenceButton;
    public Button dogButton;
    public Button brickFenceButton;
    public Button guardButton;
    public Button cameraButton;

    private int money;

    private int level;

    private int upgradeCounter;

    public GameObject upgradeHelpScreen;


    public void upgradeHelpOkButton()
    {
        upgradeHelpScreen.SetActive(false);
    }

    public void upgradeHelpButton()
    {

        upgradeHelpScreen.SetActive(true);

    }


    public void buySoilButton()
    {
        PlayerPrefs.SetInt("UpgradeLevel", 1);
        money = money - 1000;
        PlayerPrefs.SetInt("Money", money);
        PlayerPrefs.SetInt("soilActive", 0);

    }
    public void buyWoodenFenceButton()
    {
        PlayerPrefs.SetInt("UpgradeLevel", 2);
        money = money - 2000;
        PlayerPrefs.SetInt("Money", money);
        PlayerPrefs.SetInt("woodenActive", 0);

    }
    public void buySprinklersButton()
    {
        PlayerPrefs.SetInt("UpgradeLevel", 3);
        money = money - 3000;
        PlayerPrefs.SetInt("Money", money);
        PlayerPrefs.SetInt("sprinklersActive", 0);

    }
    public void buyDogButton()
    {
        PlayerPrefs.SetInt("UpgradeLevel", 4);
        money = money - 4000;
        PlayerPrefs.SetInt("Money", money);
        PlayerPrefs.SetInt("dogActive", 0);

    }
    public void buyGreenhouseButton()
    {
        PlayerPrefs.SetInt("UpgradeLevel", 5);
        money = money - 5000;
        PlayerPrefs.SetInt("Money", money);
        PlayerPrefs.SetInt("greenhouseActive", 0);

    }
    public void buyBrickFenceButton()
    {
        PlayerPrefs.SetInt("UpgradeLevel", 6);
        money = money - 6000;
        PlayerPrefs.SetInt("Money", money);
        PlayerPrefs.SetInt("brickActive", 0);

    }
    public void buyLightsButton()
    {
        PlayerPrefs.SetInt("UpgradeLevel", 7);
        money = money - 7000;
        PlayerPrefs.SetInt("Money", money);
        PlayerPrefs.SetInt("lightsActive", 0);

    }
    public void employGuardButton()
    {
        PlayerPrefs.SetInt("UpgradeLevel", 8);
        money = money - 1000;
        PlayerPrefs.SetInt("Money", money);
        PlayerPrefs.SetInt("guardActive", 0);

    }
    public void buyThermostatButton()
    {
        PlayerPrefs.SetInt("UpgradeLevel", 9);
        money = money - 9000;
        PlayerPrefs.SetInt("Money", money);
        PlayerPrefs.SetInt("thermostatActive", 0);

    }
    public void buyCamerasButton()
    {
        PlayerPrefs.SetInt("UpgradeLevel", 10);
        money = money - 10000;
        PlayerPrefs.SetInt("Money", money);
        PlayerPrefs.SetInt("camerasActive", 0);

    }


    public void backButton() {
        buyUpgradesScreen.SetActive(false);

    }

    public void openUpgradeMenu() {

        buyUpgradesScreen.SetActive(true);
    }

    public void openSeedsMenu() {

        buySeedsScreen.SetActive(true);

    }


    // Start is called before the first frame update
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        // make sure that the buttons are Active if they haven't been purchased by player and Inactive if the have
        if (PlayerPrefs.GetInt("soilActive") == 1)
        {
            soilButton.gameObject.SetActive(true);
        }
        else {

            soilButton.gameObject.SetActive(false);
        }
        if (PlayerPrefs.GetInt("woodenActive") == 1)
        {
            woodenFenceButton.gameObject.SetActive(true);
        }
        else
        {

            woodenFenceButton.gameObject.SetActive(false);
        }
        if (PlayerPrefs.GetInt("sprinklersActive") == 1)
        {
            sprinklersButton.gameObject.SetActive(true);
        }
        else
        {

            sprinklersButton.gameObject.SetActive(false);
        }
        if (PlayerPrefs.GetInt("dogActive") == 1)
        {
            dogButton.gameObject.SetActive(true);
        }
        else
        {

            dogButton.gameObject.SetActive(false);
        }
        if (PlayerPrefs.GetInt("greenhouseActive") == 1)
        {
            greenhouseButton.gameObject.SetActive(true);
        }
        else
        {

            greenhouseButton.gameObject.SetActive(false);
        }
        if (PlayerPrefs.GetInt("brickActive") == 1)
        {
            brickFenceButton.gameObject.SetActive(true);
        }
        else
        {

            brickFenceButton.gameObject.SetActive(false);
        }
        if (PlayerPrefs.GetInt("lightsActive") == 1)
        {
            lightsButton.gameObject.SetActive(true);
        }
        else
        {

            lightsButton.gameObject.SetActive(false);
        }
        if (PlayerPrefs.GetInt("guardActive") == 1)
        {
            guardButton.gameObject.SetActive(true);
        }
        else
        {

            guardButton.gameObject.SetActive(false);
        }
        if (PlayerPrefs.GetInt("thermostatActive") == 1)
        {
            thermostatButton.gameObject.SetActive(true);
        }
        else
        {

            thermostatButton.gameObject.SetActive(false);
        }
        if (PlayerPrefs.GetInt("camerasActive") == 1)
        {
            cameraButton.gameObject.SetActive(true);
        }
        else
        {

            cameraButton.gameObject.SetActive(false);
        }


        // make sure that the right buttons on the upgrade screen are made interactable dependent on the requirements
        // by default they're un-interactable
        money = PlayerPrefs.GetInt("Money");
        level = PlayerPrefs.GetInt("Level");
        upgradeCounter = PlayerPrefs.GetInt("UpgradeLevel");
        if ((money >= 1000) && (level >= 2) && (upgradeCounter == 0)) {
            soilButton.interactable = true;
        }
        if ((money >= 2000) && (level >= 4) && (upgradeCounter == 1))
        {
            woodenFenceButton.interactable = true;
        }
        if ((money >= 3000) && (level >= 6) && (upgradeCounter == 2))
        {
            sprinklersButton.interactable = true;
        }
        if ((money >= 4000) && (level >= 8) && (upgradeCounter == 3))
        {
            dogButton.interactable = true;
        }
        if ((money >= 5000) && (level >= 10) && (upgradeCounter == 4))
        {
            greenhouseButton.interactable = true;
        }
        if ((money >= 6000) && (level >= 12) && (upgradeCounter == 5))
        {
            brickFenceButton.interactable = true;
        }
        if ((money >= 7000) && (level >= 14) && (upgradeCounter == 6))
        {
            lightsButton.interactable = true;
        }
        if ((money >= 8000) && (level >= 16) && (upgradeCounter == 7))
        {
            guardButton.interactable = true;
        }
        if ((money >= 9000) && (level >= 18) && (upgradeCounter == 8))
        {
           thermostatButton.interactable = true;
        }
        if ((money >= 10000) && (level >= 20) && (upgradeCounter == 9))
        {
            cameraButton.interactable = true;
        }


        // assign the relevant bonuses that are assigned by buying the upgrades
        if (upgradeCounter == 0) {
            PlayerPrefs.SetInt("FlowerRateBonus", 0);
            PlayerPrefs.SetInt("SecurityBonus", 0);

        }
        if (upgradeCounter == 1)
        {
            PlayerPrefs.SetInt("FlowerRateBonus", 10);
            PlayerPrefs.SetInt("SecurityBonus", 0);

        }
        if (upgradeCounter == 2)
        {
            PlayerPrefs.SetInt("FlowerRateBonus", 10);
            PlayerPrefs.SetInt("SecurityBonus", 10);

        }
        if (upgradeCounter == 3)
        {
            PlayerPrefs.SetInt("FlowerRateBonus", 20);
            PlayerPrefs.SetInt("SecurityBonus", 10);

        }
        if (upgradeCounter == 4)
        {
            PlayerPrefs.SetInt("FlowerRateBonus", 20);
            PlayerPrefs.SetInt("SecurityBonus", 20);

        }
        if (upgradeCounter == 5)
        {
            PlayerPrefs.SetInt("FlowerRateBonus", 30);
            PlayerPrefs.SetInt("SecurityBonus", 20);

        }
        if (upgradeCounter == 6)
        {
            PlayerPrefs.SetInt("FlowerRateBonus", 30);
            PlayerPrefs.SetInt("SecurityBonus", 30);

        }
        if (upgradeCounter == 7)
        {
            PlayerPrefs.SetInt("FlowerRateBonus", 40);
            PlayerPrefs.SetInt("SecurityBonus", 30);

        }
        if (upgradeCounter == 8)
        {
            PlayerPrefs.SetInt("FlowerRateBonus", 40);
            PlayerPrefs.SetInt("SecurityBonus", 40);

        }
        if (upgradeCounter == 9)
        {
            PlayerPrefs.SetInt("FlowerRateBonus", 50);
            PlayerPrefs.SetInt("SecurityBonus", 40);

        }
        if (upgradeCounter == 10)
        {
            PlayerPrefs.SetInt("FlowerRateBonus", 50);
            PlayerPrefs.SetInt("SecurityBonus", 50);

        }


    }
}
