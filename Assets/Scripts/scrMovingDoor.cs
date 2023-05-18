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
    private double MovingPercent;

    //Translating
    public float MoveUnits;
    private float MovementMin;
    private float MovementMax;
    private double Movement;

    public float MoveUnitsUp;
    private float MovementUpMin;
    private float MovementUpMax;
    private double MovementUp;

    public float MoveUnitsForward;
    private float MovementForwardMin;
    private float MovementForwardMax;
    private double MovementForward;

    //Rotating
    public float RotationUnits;
    private float RotationMin;
    private float RotationMax;
    private double Rotation;

    public float RotationUnitsY;
    private float RotationYMin;
    private float RotationYMax;
    private double RotationY;

    public float RotationUnitsZ;
    private float RotationZMin;
    private float RotationZMax;
    private double RotationZ;

    // Start is called before the first frame update
    void Start()
    {
        //Set min and maximum movement
        MovementMin = gameObject.transform.position.x;
        MovementMax = gameObject.transform.position.x + MoveUnits;

        MovementUpMin = gameObject.transform.position.y;
        MovementUpMax = gameObject.transform.position.y + MoveUnitsUp;

        MovementForwardMin = gameObject.transform.position.z;
        MovementForwardMax = gameObject.transform.position.z + MoveUnitsForward;
        //Debug.Log(MovementMin);
        //Debug.Log(MovementMax);

        RotationMin = gameObject.transform.eulerAngles.x;
        RotationMax = gameObject.transform.eulerAngles.x + RotationUnits;

        RotationYMin = gameObject.transform.eulerAngles.y;
        RotationYMax = gameObject.transform.eulerAngles.y + RotationUnitsY;

        RotationZMin = gameObject.transform.eulerAngles.z;
        RotationZMax = gameObject.transform.eulerAngles.z + RotationUnitsZ;
        //Debug.Log(RotationMin);
        //Debug.Log(RotationMax);
    }

    // Update is called once per frame
    void Update()
    {
        //Get our percentage
        MovingPercent = (ConnectedLever.LeverPercent / 100);

        //Doubles are able to represent much larger numbers than a float, so it is better for coordinates
        Movement = MovementMin + (MovementMax - MovementMin) * MovingPercent;
        Rotation = RotationMin + (RotationMax - RotationMin) * MovingPercent;

        MovementUp = MovementUpMin + (MovementUpMax - MovementUpMin) * MovingPercent;
        RotationY = RotationYMin + (RotationYMax - RotationYMin) * MovingPercent;

        MovementForward = MovementForwardMin + (MovementForwardMax - MovementForwardMin) * MovingPercent;
        RotationZ = RotationZMin + (RotationZMax - RotationZMin) * MovingPercent;
        //Debug.Log(MovingPercent);
        //Debug.Log(ConnectedLever.LeverPercent);
        //Debug.Log(Movement);

        gameObject.transform.position = new Vector3((float)Movement, (float)MovementUp, (float)MovementForward);
        gameObject.transform.localEulerAngles = new Vector3((float)Rotation, (float)RotationY, (float)RotationZ);
        //Debug.Log(Movement);
    }
}
