using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class RayController : MonoBehaviour
{
    // INPUT LEGACY - public string hand; // cambiar a XRNode

    [HideInInspector]
    public Hand hand;

    // INPUT MANAGER CUSTOM - 
    // [HideInInspector]
    // public Hand hand;
    // public InputManager.ButtonOptions toggleButton;

    public bool toggle;

    private void Start()
    {
        // INPUT MANAGER CUSTOM - hand = GetComponent<Hand>();
        hand = GetComponent<Hand>();
    }


    public Transform rayOrigin;
    public GameObject otherHand;

    public CanvasRay canvasRay;

    private void Update()
    {
        EnableDisableControllersToggle();
    }

    void EnableDisableControllersToggle()
    {
        canvasRay.lineRenderer.SetPosition(0, transform.position);

        // ESTO ES PARA QUE NO ESTEN LAS DOS ACTIVAS A LA VEZ      
        // otherHand.GetComponent<RayController>().canvasRay.lineRenderer.gameObject.SetActive(false);
        // otherHand.GetComponent<RayController>().toggle = false;

        if (!canvasRay.pointingCP)
        {
            canvasRay.lineRenderer.gameObject.SetActive(false);
        }
        else
        {
            canvasRay.lineRenderer.gameObject.SetActive(true);
            canvasRay.lineRenderer.SetPosition(0, rayOrigin.position);
        }

    }
}

