using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;
using UnityEngine.Events;

public class ButtonVR : MonoBehaviour
{
    public GameObject button;
    public UnityEvent onPress;
    public UnityEvent onRelease;
    private GameObject presser;
    private AudioSource sound;
    bool isPressed;

    // Start is called before the first frame update
    void Start()
    {
        // Get our sound effect
        // Set button to false
        sound = GetComponent<AudioSource>();
        isPressed = false;
    }

    // Triggers when a collider enters
    private void OnTriggerEnter(Collider other)
    {
        //Check if button isn't being pressed already
        if (!isPressed)
        {
            //Set button to pressed position
            button.transform.localPosition = new Vector3(0, 0.015f, 0);
            //presser = other.gameObject;
            //Evoke on press event and play sound
            onPress.Invoke();
            sound.Play();
            isPressed = true;
            Debug.Log("Trigger Enter ");
        }
    }

    // When the collider leaves the button
    private void OnTriggerExit(Collider presser)
    {
        Debug.Log("Trigger Exit");
        button.transform.localPosition = new Vector3(0, 0.030f, 0);
        onRelease.Invoke();
        isPressed = false;

        //if (other == presser)
       // {
       //     button.transform.localPosition = new Vector3(0, -0.015f, 0);
        //    onRelease.Invoke();
        //    isPressed = false;
        //    Debug.Log("Trigger Exit 2");
        //}
    }

    //Trigger this event
    public void SpawnSphere()
    {
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        sphere.transform.localPosition = new Vector3(0, 1, 2);
        sphere.AddComponent<Rigidbody>();
    }
}
