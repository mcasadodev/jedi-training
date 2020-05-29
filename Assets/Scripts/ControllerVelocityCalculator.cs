using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerVelocityCalculator : MonoBehaviour
{
    Vector3 previous;
    Vector3 velocityVector;
    public float velocity;
    public Transform plane;



    // Update is called once per frame
    void Update()
    {
        velocityVector = (transform.position - previous) / Time.deltaTime;
        velocity = velocityVector.magnitude;

        Debug.DrawRay(transform.position, (transform.position - previous) * 200, Color.green);

        if (velocity > 0.5f)
        {
            Vector3 cc = transform.position - previous;
            //plane.localRotation = Quaternion.Euler(0, 0, 90);
            plane.localRotation = Quaternion.FromToRotation(plane.up, cc);

            //plane.rotation = Quaternion.LookRotation(transform.position - previous);
            //plane.rotation *= Quaternion.Euler(0, 0, 90);
        }

        previous = transform.position;


        plane.position = transform.position;



    }
}
