using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cuttable : MonoBehaviour
{
    void Start()
    {
        Destroy(gameObject, 2);
    }

    void Update()
    {
        if (transform.position.y < -10f)
            Destroy(this.gameObject);
    }
}
