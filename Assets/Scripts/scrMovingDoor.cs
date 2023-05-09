using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
//using System.Diagnostics;
using UnityEngine;

public class scrMovingDoor : MonoBehaviour
{
    //Get our Lever and its Script
    public LeverRotationVR ConnectedLever;

    //Percentage
    public double MovingPercent;

    //Translating
    public float MoveUnits;
    private float MovementMin;
    private float MovementMax;
    private float MovementValue;
    private double Movement;

    //Rotating
    private float RotationMin;
    public float RotationMax;
    public float Rotation;

    // Start is called before the first frame update
    void Start()
    {
        //Set min and maximum movement
        MovementMin = gameObject.transform.position.x;
        MovementMax = gameObject.transform.position.x + MoveUnits;
        //Debug.Log(MovementMin);
        //Debug.Log(MovementMax);
    }

    // Update is called once per frame
    void Update()
    {
        //Get our percentage
        MovingPercent = (ConnectedLever.LeverPercent / 100);

        //Doubles are able to represent much larger numbers than a float, so it is better for coordinates
        Movement = MovementMin + (MovementMax - MovementMin) * MovingPercent;
        //Debug.Log(MovingPercent);
        //Debug.Log(ConnectedLever.LeverPercent);
        //Debug.Log(Movement);

        gameObject.transform.position = new Vector3((float)Movement, transform.position.y, transform.position.z);
        Debug.Log(Movement);
    }
}
