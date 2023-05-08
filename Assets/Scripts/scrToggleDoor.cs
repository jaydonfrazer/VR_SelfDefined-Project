using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrToggleDoor : MonoBehaviour
{
    public Material OpenMaterial;
    public Material CloseMaterial;
    //Get and set the bool into the script for UnityEvents
    public bool Open { get; set; }

    // Update is called once per frame
    void Update()
    {
        if (Open == true)
        {
            gameObject.GetComponent<Collider>().enabled = false;
            gameObject.GetComponent<Renderer>().material = OpenMaterial;
        }
        else
        {
            gameObject.GetComponent<Collider>().enabled = true;
            gameObject.GetComponent<Renderer>().material = CloseMaterial;
        }
    }
}
