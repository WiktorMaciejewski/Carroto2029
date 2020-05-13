using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class StatusBarManager : MonoBehaviour
{
    public Text moneyText;
    public Text seedsText;
    public Text levelText;
    public Text experienceText;
    public Text carrotAmountText;
    public Text timerText;
    
    private int moneyAmount;
    private int seedsAmount;
    private int level;
    private int currentExperienceAmount;
    private int nextLevelExperienceAmount;
    private int carrotAmount;
    private float timer;

    private StatsScript statsManager;

    public GameObject[] nurtureLevel;

    public int nurtureValue;

    private int nurture0;
    private int nurture1;
    private int nurture2;
    private int nurture3;
    private int nurture4;
    private int nurture5;

    

    // Start is called before the first frame update
    void Start()
    {

        
        statsManager = FindObjectOfType<StatsScript>();
        /*
        statsManager.loadStatus();
        statsManager.moneyAmount.ToString();
        */
    }

    // Update is called once per frame
    void Update()
    {




        statsManager.loadStatus();



        moneyAmount = statsManager.moneyAmount;
        seedsAmount = statsManager.seedsAmount;
        level = statsManager.level;
        currentExperienceAmount = statsManager.currentExperienceAmount;
        nextLevelExperienceAmount = statsManager.nextLevelExperienceAmount;
        carrotAmount = statsManager.carrotAmount;
        timer = statsManager.timer;

        moneyText.text = "£" + moneyAmount.ToString();
        seedsText.text = seedsAmount.ToString();
        levelText.text = level.ToString();
        experienceText.text = currentExperienceAmount.ToString() + " / " + nextLevelExperienceAmount.ToString();
        carrotAmountText.text = carrotAmount.ToString();
        timerText.text = Mathf.RoundToInt(timer).ToString();




        statsManager.nurtureLevelAdd();

        nurture0 = PlayerPrefs.GetInt("Nurture0");
        nurture1 = PlayerPrefs.GetInt("Nurture1");
        nurture2 = PlayerPrefs.GetInt("Nurture2");
        nurture3 = PlayerPrefs.GetInt("Nurture3");
        nurture4 = PlayerPrefs.GetInt("Nurture4");
        nurture5 = PlayerPrefs.GetInt("Nurture5");


        // activate the Soil Nurture Bar
        if (nurture0 == 1) {
            nurtureLevel[0].SetActive(true);
        }
        if (nurture1 == 1)
        {
            nurtureLevel[1].SetActive(true);
        }
        if (nurture2 == 1)
        {
            nurtureLevel[2].SetActive(true);
        }
        if (nurture3 == 1)
        {
            nurtureLevel[3].SetActive(true);
        }
        if (nurture4 == 1)
        {
            nurtureLevel[4].SetActive(true);
        }
        if (nurture5 == 1)
        {
            nurtureLevel[5].SetActive(true);
        }


        // deactivate the Soil Nurture Bar
        if (nurture0 == 0)
        {
            nurtureLevel[0].SetActive(false);
        }
        if (nurture1 == 0)
        {
            nurtureLevel[1].SetActive(false);
        }
        if (nurture2 == 0)
        {
            nurtureLevel[2].SetActive(false);
        }
        if (nurture3 == 0)
        {
            nurtureLevel[3].SetActive(false);
        }
        if (nurture4 == 0)
        {
            nurtureLevel[4].SetActive(false);
        }
        if (nurture5 == 0)
        {
            nurtureLevel[5].SetActive(false);
        }


        statsManager.saveStatus();


    }

   
    
    }

