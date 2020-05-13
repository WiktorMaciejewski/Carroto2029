using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    public string upgradeSceneName;
    public string nurtureSceneName;
    public string plantSceneName;
    public string sellSceneName;
    public string overviewSceneName;
    

    public void upgradeButton() {

        Application.LoadLevel(upgradeSceneName);
    }

    public void nurtureButton()
    {

        Application.LoadLevel(nurtureSceneName);
    }
    public void plantButton()
    {

        Application.LoadLevel(plantSceneName);
    }
    public void sellButton()
    {

        Application.LoadLevel(sellSceneName);
    }

    public void backButton() {


        Application.LoadLevel(overviewSceneName);
    }



   

}
