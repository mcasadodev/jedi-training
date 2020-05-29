using UnityEngine;
using System;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class SwordCutter : MonoBehaviour
{
    public Material capMaterial;
    public GameObject sparks;

    // SOLO PARA PODER ACTIVAR Y DESACTIVAR EL SCRIPT
    private void Update()
    {

    }

    private void OnTriggerEnter(Collider other) // COMPROBAR SI ES MEJOR OnCollisionEnter()
    {
        GameObject victim = other.gameObject;

        GameObject[] pieces = BLINDED_AM_ME.MeshCut.Cut(victim, transform.position, transform.right, capMaterial);
        Instantiate(sparks, pieces[1].transform.position, Quaternion.identity);
        //Destroy(sparks, 2f);


        if (!pieces[1].GetComponent<Rigidbody>())
        {
            Rigidbody rbtemp = pieces[1].AddComponent<Rigidbody>();
            rbtemp.interpolation = RigidbodyInterpolation.Interpolate;
            rbtemp.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;

            MeshCollider mctemp = pieces[1].AddComponent<MeshCollider>();
            mctemp.convex = true;
            StartCoroutine(Wait(mctemp));
            //mctemp.isTrigger = true;
        }

        Destroy(pieces[1], 1);
    }

    IEnumerator Wait(MeshCollider mctemp) {
        yield return new WaitForSeconds(50 * Time.deltaTime);
        mctemp.isTrigger = true;
    }
}