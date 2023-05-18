using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrTeleportBox : MonoBehaviour
{
    //Get our box
    public GameObject ItemtoTeleport;

    //Set Box position to Teleport
    public void TeleportItem()
    {
        ItemtoTeleport.gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y+1, gameObject.transform.position.z);
    }
}
