using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseModeButtonScript : MonoBehaviour
{
    public string chaseModeLevel;

    public void ChaseModeButton() {
        Application.LoadLevel(chaseModeLevel);

    }
}
