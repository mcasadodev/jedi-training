using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportController : MonoBehaviour
{
    public Teleport teleport;
    public bool pointingTeleport;
    public GameObject grabber;

    private void Update()
    {
        pointingTeleport = teleport.isAimingTeleport;

        if (pointingTeleport)
            grabber.GetComponent<Collider>().enabled = false;
        else
            grabber.GetComponent<Collider>().enabled = true;

    }
}
