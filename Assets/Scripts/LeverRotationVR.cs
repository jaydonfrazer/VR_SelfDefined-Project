using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LeverRotationVR : MonoBehaviour
{
    public GameObject lever;
    float LeverCurrent;
    float LeverPosition = 45;
    public int LeverPercent;
    public int LeverOnOffMiddle;
    public UnityEvent LeverON;
    public UnityEvent LeverOFF;
    private AudioSource sound;
    bool isOn;
    bool isOff;

    // Start is called before the first frame update
    void Start()
    {
        switch(LeverOnOffMiddle)
        {
            case 0:
                //Lever is in ON position
                gameObject.transform.localEulerAngles = new Vector3(60, gameObject.transform.eulerAngles.y, gameObject.transform.eulerAngles.z);
                break;
            case 1:
                //Lever is in OFF position
                gameObject.transform.localEulerAngles = new Vector3(-60, gameObject.transform.eulerAngles.y, gameObject.transform.eulerAngles.z);
                break;
            case 2:
                //Lever is in MIDDLE position
                gameObject.transform.localEulerAngles = new Vector3(gameObject.transform.eulerAngles.x, gameObject.transform.eulerAngles.y, gameObject.transform.eulerAngles.z);
                break;
        }

        //Set up sound and variables

        sound = GetComponent<AudioSource>();

        isOn = false;
        isOff = false;

        ////Set Rotation
        //gameObject.transform.localEulerAngles = new Vector3(LeverPosition, gameObject.transform.eulerAngles.y, gameObject.transform.eulerAngles.z);

        //Debug.Log(LeverPosition);
        //Debug.Log(LeverPercent);
    }

    // Update is called once per frame
    void Update()
    {
        //// Get Lever's rotation ////
        //Debug.Log(gameObject.transform.localEulerAngles);

        ////Use euler angles to get a fixed point of rotation
        LeverCurrent = gameObject.transform.localEulerAngles.x;
        if (LeverCurrent > 45)
        {
            ////Get negative angles if rotation is going backwards
            LeverCurrent = LeverCurrent - 360;
        }

        LeverPercent = Mathf.RoundToInt((LeverPosition + LeverCurrent) / 90 * 100);

        if (LeverPercent < 0)
        {
            LeverPercent = 100;
        }

        //Set ON and OFF events depending on percentage
        if (LeverPercent == 100 && !isOn)
        {
            sound.Play();
            LeverON.Invoke();
            isOn = true;
            //Debug.Log(isOn);
        }
        else if (LeverPercent == 0 && !isOff)
        {
            sound.Play();
            LeverOFF.Invoke();
            isOff = true;
            //Debug.Log(isOff);
        }
        else if (LeverPercent != 100)
        {
            isOn = false;
        }
        else if (LeverPercent != 0)
        {
            isOff = false;
        }

        //// Check Percentages and Current Lever Rotation ////
        //Debug.Log(LeverCurrent);
        //Debug.Log(LeverPercent);
    }
}
