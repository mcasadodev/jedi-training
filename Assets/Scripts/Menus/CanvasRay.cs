using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class CanvasRay : MonoBehaviour
{
    public float length = 10;
    public LineRenderer lineRenderer = null;
    public Transform rayOrigin;
    public LayerMask interact;
    public bool pointingCP;
    //public GameObject dot;

    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(rayOrigin.position, rayOrigin.forward, out hit, length * 1000, interact)) //Mathf.Infinity
        {
            pointingCP = true;
            lineRenderer.SetPosition(1, hit.point);
        }
        else
        {
            pointingCP = false;
            lineRenderer.SetPosition(1, rayOrigin.forward * length);
        }
    }

}
