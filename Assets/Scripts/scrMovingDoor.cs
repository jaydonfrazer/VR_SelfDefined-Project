using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
//using System.Diagnostics;
using UnityEngine;

public class scrMovingDoor : MonoBehaviour
{
    //Get our Levers and their Scripts
    public LeverRotationVR ConnectedLever;
    public LeverRotationVR MoveUpLever;
    public LeverRotationVR MoveForwardLever;

    public LeverRotationVR RotateXLever;
    public LeverRotationVR RotateYLever;
    public LeverRotationVR RotateZLever;


    //Percentage
    private double MovingPercent;
    private double MovingUpPercent;
    private double MovingForwardPercent;

    private double RotatingXPercent;
    private double RotatingYPercent;
    private double RotatingZPercent;

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
        MovingUpPercent = (MoveUpLever.LeverPercent / 100);
        MovingForwardPercent = (MoveForwardLever.LeverPercent / 100);

        RotatingXPercent = (RotateXLever.LeverPercent / 100);
        RotatingYPercent = (RotateYLever.LeverPercent / 100);
        RotatingZPercent = (RotateZLever.LeverPercent / 100);

        //Doubles are able to represent much larger numbers than a float, so it is better for coordinates
        Movement = MovementMin + (MovementMax - MovementMin) * MovingPercent;
        Rotation = RotationMin + (RotationMax - RotationMin) * RotatingXPercent;

        MovementUp = MovementUpMin + (MovementUpMax - MovementUpMin) * MovingUpPercent;
        RotationY = RotationYMin + (RotationYMax - RotationYMin) * RotatingYPercent;

        MovementForward = MovementForwardMin + (MovementForwardMax - MovementForwardMin) * MovingForwardPercent;
        RotationZ = RotationZMin + (RotationZMax - RotationZMin) * RotatingZPercent;
        //Debug.Log(MovingPercent);
        //Debug.Log(ConnectedLever.LeverPercent);
        //Debug.Log(Movement);

        gameObject.transform.position = new Vector3((float)Movement, (float)MovementUp, (float)MovementForward);
        gameObject.transform.localEulerAngles = new Vector3((float)Rotation, (float)RotationY, (float)RotationZ);
        //Debug.Log(Movement);
    }
}
