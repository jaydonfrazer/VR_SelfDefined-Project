using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Percentage : MonoBehaviour
{
    //Set reference
    public TextMeshProUGUI counterText;
    public double counter;

    //Get our Lever and its Script
    public LeverRotationVR ConnectedLever;

    public void Update()
    {
        counter = ConnectedLever.LeverPercent;
        counterText.text = "Lever "+counter.ToString()+"%";
    }
}
