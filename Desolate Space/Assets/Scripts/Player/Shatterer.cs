using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shatterer : MonoBehaviour
{
    public float shatterPoint = 450f;

    private PlayerFunctions playerFns;
    private Rigidbody rb;
    private Rigidbody otherRb;

    private void Start()
    {
        playerFns = GameObject.Find("Player Functions").GetComponent<PlayerFunctions>();
        rb = GetComponent<Rigidbody>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Player"))
            return;

        otherRb = collision.gameObject.GetComponent<Rigidbody>();

        Vector3 impulse = collision.impulse;
        Vector3 force = impulse / Time.deltaTime;

        float forceOverMass = force.magnitude / rb.mass;
        
        // Print acceleration caused by collision
        // Debug.Log(M/V: " + forceOverMass);

        if (forceOverMass > shatterPoint)
        {
            Shatter(gameObject);
        }
    }

    private void Shatter(GameObject planet)
    {
        Rigidbody planetRb = planet.GetComponent<Rigidbody>();
        playerFns.SpawnShatteredPlanet(planet.transform, planetRb.mass);
        Destroy(planet.transform.parent.gameObject);
    }
}
