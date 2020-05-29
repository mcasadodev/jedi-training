using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereSpawner : MonoBehaviour
{
    public GameObject[] prefab;
    public float spawnTime = 1f;
    public float spawnforce = 20;

    void Start()
    {
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        while (true)
        {
            GameObject go = Instantiate(prefab[Random.Range(0, prefab.Length)]);
            go.transform.parent = this.transform;
            Rigidbody temp = go.GetComponent<Rigidbody>();

            temp.velocity = new Vector3(0, 5f * spawnforce, .5f * spawnforce);
            temp.angularVelocity = new Vector3(Random.Range(-5f * spawnforce, 5 * spawnforce), 0, Random.Range(-5f * spawnforce, 5 * spawnforce));
            temp.useGravity = true;

            Vector3 pos = transform.position;
            pos.x += Random.Range(-0.1f, 0.1f);
            go.transform.position = pos;

            //if (!go.activeInHierarchy)
            yield return new WaitForSeconds(Random.Range(spawnTime * 1f, spawnTime * 1.5f));
            //else
            //    yield return new WaitForSeconds(5f); // ESTE METODO NO ES BUENO MEJOR HACERLO ASEGURANDOSE DE QUE LA FRUTA NO ESTA ACTIVA
        }
    }
}
