using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class ComponentController : MonoBehaviour
{
    // INPUT LEGACY - public string hand; // cambiar a XRNode

    [HideInInspector]
    public Hand hand;

    // INPUT MANAGER CUSTOM - 
    // [HideInInspector]
    // public Hand hand;
    // public InputManager.ButtonOptions toggleButton;

    private void Start()
    {
        // INPUT MANAGER CUSTOM - hand = GetComponent<Hand>();
        hand = GetComponent<Hand>();
    }


    public bool toggle;
    public Grabber grabber;
    public Transform rayOrigin;
    public GameObject otherHand;

    public CanvasRay canvasRay;
    public TeleportController teleportController;

    private void Update()
    {
        if (grabber.itemGrabbed == null)
            EnableDisableControllersToggle();
    }

    void EnableDisableControllersToggle()
    {
        canvasRay.lineRenderer.SetPosition(0, transform.position);

        if (Input.GetButtonDown("primaryButton_" + hand.hand))
        // INPUT MANAGER CUSTOM - if (hand.input.GetButtonDown(toggleButton, hand.hand))
        {
            toggle = !toggle;
        }


        if (toggle)
        {
            //ESTO ES PARA QUE NO SE PUEDA ACTIVAR EL TELETRANSPORTE SI ALGUNA ESTA ACTIVA 

            if (hand.hand == teleportController.teleport.hand.hand)
                teleportController.teleport.isPosibleTeleport = false;
            else
                teleportController.teleport.isPosibleTeleport = true;

            //ESTO ES PARA QUE NO ESTEN LAS DOS ACTIVAS A LA VEZ              
            otherHand.GetComponent<XRRayInteractor>().enabled = false;
            otherHand.GetComponent<ComponentController>().canvasRay.lineRenderer.gameObject.SetActive(false);
            otherHand.GetComponent<ComponentController>().toggle = false;

            //if (!teleportController.pointingTeleport)
            //{
            if (!canvasRay.pointingCP)
            {
                GetComponent<XRRayInteractor>().enabled = true;
                canvasRay.lineRenderer.gameObject.SetActive(false);
            }
            else
            {
                GetComponent<XRRayInteractor>().enabled = false;
                canvasRay.lineRenderer.gameObject.SetActive(true);
                canvasRay.lineRenderer.SetPosition(0, rayOrigin.position);
            }
            //}
        }
        else
        {
            teleportController.teleport.isPosibleTeleport = true;

            GetComponent<XRRayInteractor>().enabled = false;
            canvasRay.lineRenderer.gameObject.SetActive(false);
        }
    }
}

