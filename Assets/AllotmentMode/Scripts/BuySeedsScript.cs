using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuySeedsScript : MonoBehaviour
{

    
    public InputField inputField;
    public GameObject buySeedsScreen;
    public GameObject errorSeedsScreen;
    private int currentSeeds;
    private int seedsAmount;
    private int money;
    private int deductMoney;


    public void okErrorSeedsButton() {

        errorSeedsScreen.SetActive(false);
        buySeedsScreen.SetActive(false);
    }


    public void confirmButton() {

        money = PlayerPrefs.GetInt("Money");
        currentSeeds = PlayerPrefs.GetInt("Seeds");
        seedsAmount = int.Parse(inputField.text);
        deductMoney = 1 * seedsAmount;

        money = money - deductMoney;

        if (money < 0)
        {
            errorSeedsScreen.SetActive(true);
        }
        else
        {



            currentSeeds = currentSeeds + seedsAmount;

            PlayerPrefs.SetInt("Seeds", currentSeeds);
            PlayerPrefs.SetInt("Money", money);
            buySeedsScreen.SetActive(false);
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
